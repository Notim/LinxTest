using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using testeLinx.Services;

namespace testeLinx {

    public class Startup {
    
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services) {

            services.AddCors(options => {
                options.AddPolicy("AllowOrigin", 
                   builder => {
                       builder.WithOrigins("https://localhost:3000", "http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                   });
            });

            
            services.AddControllersWithViews();

            services.AddScoped<IProductServicesContract, ProductServices>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCors("AllowOrigin");
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}"); });
            
            /*app.Use(async (context, next) => {
                context.Response.Headers.Add("Access-Control-Allow-Origin",  "*");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE");
                await next.Invoke();
            });*/
    
        }

    }

}