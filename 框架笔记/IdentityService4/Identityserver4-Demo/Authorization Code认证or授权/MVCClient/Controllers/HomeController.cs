using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MVCClient.Models;
using static IdentityModel.OidcConstants;

namespace MVCClient.Controllers
{
    [Authorize]
    public  class HomeController : Controller
    {
        public async Task< IActionResult> Index()
        {
            var client = new HttpClient();
            //这个发现文档在这里没用
            //var disco=  await client.GetDiscoveryDocumentAsync();
            var token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            client.SetBearerToken(token);

            var response= await client.GetAsync("http://localhost:5001/identity");

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode==HttpStatusCode.Unauthorized)
                {
                    await RenewTokenAsync();
                    return RedirectToAction();
                }
                throw new Exception();
            }

            var str = await response.Content.ReadAsStringAsync();

            ViewBag.str = str;

            return View();
        }

        public async Task< IActionResult> Privacy()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var IdToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            //code只能用一次，当使用code请求了accesstoken和id token之后会从客户端移除
            var code = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.Code);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        //整个更新操作分3部分：1 重新请求token  2 重新请求身份认证 3 新的身份认证拿着新的token进行重新登陆
        private async Task<string> RenewTokenAsync() {
            //重新请求token
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000/");

            //把现有的RefreshToken提取出来
            var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            //重新获取token
            var newtoken = await client.RequestRefreshTokenAsync(new RefreshTokenRequest {
                Address= disco.TokenEndpoint,
                ClientId = "MVC Client",
                Scope= "api1 openid profile offline_access",
                ClientSecret = "MVC client",
                GrantType= OpenIdConnectGrantTypes.RefreshToken,
                RefreshToken= refreshToken
            });
            //请求token完毕

            //整理token
            if (newtoken.IsError)
            {
                throw new Exception(newtoken.Error);
            }
           
                var expirseAt = DateTime.UtcNow + TimeSpan.FromSeconds(newtoken.ExpiresIn);

                var tokens = new[] {
                    new AuthenticationToken{ Name=OpenIdConnectParameterNames.IdToken,Value=newtoken.IdentityToken},
                    new AuthenticationToken{ Name=OpenIdConnectParameterNames.AccessToken,Value=newtoken.AccessToken },
                    new AuthenticationToken{ Name=OpenIdConnectParameterNames.RefreshToken,Value=newtoken.RefreshToken},
                    new AuthenticationToken{ Name="expires_at",Value=expirseAt.ToString("o",CultureInfo.InvariantCulture)},
                };
            //整理token完毕

            //重新进行身份认证
            var currentAuthenticationResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //将新的token给新的身份认证
            currentAuthenticationResult.Properties.StoreTokens(tokens);

            //新的身份认证拿着新的token进行重新登陆
            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    currentAuthenticationResult.Principal, 
                    currentAuthenticationResult.Properties
                    );

            //返回新的token，供消费者使用
            return newtoken.AccessToken;            
        }
    }
}
