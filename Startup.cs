using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ISStudySpot.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace ISStudySpot
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = "Data Source=sqlsv-instance1.ce61i890rwzw.us-west-2.rds.amazonaws.com,1433; Initial Catalog=ISStudySpot; Persist Security Info=True; User ID=sqlsv_i1_admin; Password=goKCaG86rsKVhtET3;";
        	services.AddDbContext<ISStudySpotContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "study",
                    template: "{controller=Study}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "semester-classes",
                    template: "{controller=Study}/{action=semesters}/{id?}");

                routes.MapRoute(
                    name: "classes",
                    template: "{controller=Classes}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "studyresources",
                    template: "{controller=Classes}/{action=studyresources}/{id?}");

                routes.MapRoute(
                    name: "post",
                    template: "{controller=Classes}/{action=post}/{id?}");

                routes.MapRoute(
                    name: "about",
                    template: "{controller=About}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "contact",
                    template: "{controller=Contact}/{action=Index}/{id?}");

            });
        }
    }
}
