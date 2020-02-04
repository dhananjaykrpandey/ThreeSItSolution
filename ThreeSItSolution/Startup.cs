using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThreeSItSolution.Models;

namespace ThreeSItSolution
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
            services.AddResponseCompression();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddWebOptimizer(pipeline =>
            {
                pipeline.MinifyJsFiles("js/main.js", "js/site.js");
                pipeline.MinifyCssFiles("css/**/*.css");
                
            });

            services.AddDbContext<Db3SItSoultion>(options => options.UseSqlServer(Configuration.GetConnectionString("DB3SConnection")));
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                //options.AppendTrailingSlash = true;
            });

            //var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            //services.AddSingleton(emailConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseWebOptimizer();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
