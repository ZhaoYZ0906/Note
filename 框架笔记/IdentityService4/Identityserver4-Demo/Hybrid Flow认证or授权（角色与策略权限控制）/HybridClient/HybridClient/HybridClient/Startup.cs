using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using HybridClient.Handler;
using HybridClient.Requirements;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HybridClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //如果不加这句则请求到的相关角色信息名会变成一些http地址来显示，加上比较容易看是什么属性
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,option=> {
                    //没有权限时候的跳转地址
                    option.AccessDeniedPath = "/Authorization/AccessDenied";
                })
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ClientId = "hybrid client";
                    options.ClientSecret = "hybrid secrest";
                    options.SaveTokens = true;
                    options.ResponseType = "code id_token";

                    options.Scope.Clear();
                    //需要请求的东西
                    options.Scope.Add("api1");
                    options.Scope.Add(OidcConstants.StandardScopes.OpenId);
                    options.Scope.Add(OidcConstants.StandardScopes.Profile);
                    options.Scope.Add(OidcConstants.StandardScopes.Email);
                    options.Scope.Add(OidcConstants.StandardScopes.Phone);
                    options.Scope.Add(OidcConstants.StandardScopes.Address);
                    options.Scope.Add(OidcConstants.StandardScopes.OfflineAccess);
                    options.Scope.Add("roles");
                    options.Scope.Add("locations");


                    //UseAuthentication()中间件中会自动给自动过滤掉一部分claims属性，如果某些属性不想被过滤掉可以：
                    //所有要过滤掉的元素都在ClaimActions中，所以我们不想被过滤的属性从ClaimActions中移除即可
                    options.ClaimActions.Remove("nbf");
                    options.ClaimActions.Remove("amr");
                    options.ClaimActions.Remove("exp");

                    //假如我们想过滤掉某个属性但是ClaimActions中没有则可以：
                    //ClaimActions中有add方法和这个方法效果一直不过这个使用string比较方便
                    //方法命名有点混乱  DeleteClaim我们想删除哪个  add将哪个添加到删除的集合 Remove将哪个从删除的集合中移除
                    options.ClaimActions.DeleteClaim("sid");
                    options.ClaimActions.DeleteClaim("sub");
                    options.ClaimActions.DeleteClaim("idp");

                    //在请求到的cilam（scope里面请求的都是cilam）中的某些属性不会自动被mvc识别，需要设置映射
                    //TokenValidationParameters获取或设置用于验证标识令牌的参数。
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType=JwtClaimTypes.Name,
                        RoleClaimType=JwtClaimTypes.Role
                    };


                });

            services.AddAuthorization(option=> {
                //option.AddPolicy("A", builder => {
                //    builder.RequireAuthenticatedUser();
                //    builder.RequireClaim(JwtClaimTypes.FamilyName, "Smith");
                //    builder.RequireClaim("location", "somewhere");
                //});

                option.AddPolicy("A", builder => {
                    builder.AddRequirements(new ARequire());
                });
            });

            services.AddSingleton<IAuthorizationHandler, AHandler>();
        }
        

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
