using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_store.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ASP_store
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=(localdb)\\SQLSERVER; Database=ASPStore; User ID='sa'; Password='sa'"));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "pagintaion",
                        template: "Products/Page{productPage}",
                        defaults: new { Controller = "Product", action = "List" }
                        );
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Product}/{action=List}/{id?}"
                        );
                });
            }
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
