using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCFornecedores.Data;
using MVCFornecedores.Data.Repository;
using MVCFornecedores.Services;
using Newtonsoft.Json;
using System.Reflection;

namespace MVCFornecedores
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddDbContext<FornecedorContext>();

                services.AddTransient<IMailService, NullMailService>();

                services.AddTransient<DataSeeder>();

                services.AddAutoMapper(Assembly.GetExecutingAssembly());

                services.AddTransient<IDataRepository, DataRepository>();

                services.AddControllersWithViews()
                  .AddRazorRuntimeCompilation()
                  .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

                services.AddRazorPages();
            }
            catch (System.Exception)
            {

                throw;
            }
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
                // Add Error Page
                //app.UseExceptionHandler("/Fornecedores/Error");
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=App}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute("Fallback",
            //      "{controller}/{action}/{id?}",
            //      new { controller = "Fornecedores", action = "Index" });

            //    endpoints.MapRazorPages();
            //});
        }
    }
}
