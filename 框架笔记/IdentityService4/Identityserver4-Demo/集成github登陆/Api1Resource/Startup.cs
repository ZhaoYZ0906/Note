using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Api1Resource
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddMvcCore()
            .AddAuthorization()
            .AddJsonFormatters();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme).
                AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:5000";
                options.ApiName = "api1";
                options.RequireHttpsMetadata = false;
                options.ApiSecret = "api1 secrets";
            });
            //.AddJwtBearer("Bearer", options =>
            //{
            //    options.Authority = "http://localhost:5000";
            //    options.RequireHttpsMetadata = false;
            //    options.Audience = "api1";
            //});

            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("AngularClientOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AngularClientOrigin"));
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AngularClientOrigin");

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
