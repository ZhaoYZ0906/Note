using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace MVCClient
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

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(o=> {
                //这里其实写字符串也可以，只要和下面对应起来就行
                o.DefaultScheme=CookieAuthenticationDefaults.AuthenticationScheme;//字符串常量写的是Cookies
                o.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;//字符串常量写的是OpenIdConnect
            }).
            AddCookie(CookieAuthenticationDefaults.AuthenticationScheme).
            AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, o=> {
                o.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.Authority = "http://localhost:5000";
                o.RequireHttpsMetadata = false;
                o.ClientId = "MVC Client";
                o.ClientSecret = "MVC client";
                o.SaveTokens = true;
                o.ResponseType = "code";

                o.Scope.Clear();
                o.Scope.Add("api1");
                o.Scope.Add(OidcConstants.StandardScopes.OpenId);
                o.Scope.Add(OidcConstants.StandardScopes.Profile);

                //请求RefreshToken，注释写的是什么脱机也能请求什么的。。。
                o.Scope.Add(OidcConstants.StandardScopes.OfflineAccess);
            });
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

            app.UseAuthentication();

            app.UseStaticFiles();
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
