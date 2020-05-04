using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Uaic.Tap2020Demo.DataAccess;
using Uaic.Tap2020Demo.DataAccess.Repositories;
using Uaic.Tap2020Demo.DataAccess.SqlServer;
using Uaic.Tap2020Demo.DataAccess.SqlServer.Repositories;

namespace Tap2020Demo.Web
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
            services.AddLocalization(/*options => options.ResourcesPath = "Resources"*/);
            services.AddControllersWithViews();
            services.AddTransient<Tap2020DemoContext>(_ =>
            {
                var config = _.GetService<IConfiguration>();
                var connString = config.GetConnectionString("Tap2020");
                return new Tap2020DemoContext(connString);
            });
            services.AddTransient<IDataRepository, DataRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            var supportedCultures = new[]
            {
                new CultureInfo("ro-RO")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ro-RO"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(null, "BackOffice/Customers", new { area = "BackOffice", controller = "Customers", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
