using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
namespace mvcClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            

            services.AddAuthentication("Bearer")
                //.AddIdentityServerAuthentication(options =>
                //{
                //    options.Authority = "http://localhost:5000";
                //    options.ApiName = "api1";
                //    options.RequireHttpsMetadata = false;
                //    options.ApiSecret = "api1 secret";
                //});
                .AddJwtBearer("Bearer", o =>
            {
                o.Authority = "http://localhost:5000";
                o.RequireHttpsMetadata = false;
                o.Audience = "api1";
                //设置每隔多少分钟检查一次token
                // o.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(1);
                //token必须要有超时时间
                //o.TokenValidationParameters.RequireExpirationTime = true;
            });

            services.AddMemoryCache();

            services.AddCors(option=> {
                option.AddPolicy("angularclient", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.Configure<MvcOptions>(option => {
                option.Filters.Add(new CorsAuthorizationFilterFactory("angularclient"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("angularclient");
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
