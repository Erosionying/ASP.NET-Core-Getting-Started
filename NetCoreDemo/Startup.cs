using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreDemo.Services;
using NetCoreDemo.Settings;

namespace NetCoreDemo
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
         public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddSingleton<ICinemaService, CinemaMemoryService>();
            services.AddSingleton<IMovieService, MovieMemoryService>();

            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        }

         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if(env.IsProduction())
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }
            


            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(t => t.MapDefaultControllerRoute());
            
           
        }
    }
}
