using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ASP_store.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            //services.AddHttpContextAccessor();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
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
                app.UseSession();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: null,
                        template: "{category}/Page{productPage:int}",
                        defaults: new { controller = "Product", action = "List" }
                        );
                    routes.MapRoute(
                        name: null,
                        template: "Page{productPage:int}",
                        defaults: new { controller = "Product", action = "List", productPage = 1 }
                        );
                    routes.MapRoute(
                        name: null,
                        template: "{category}",
                        defaults: new { controller = "Product", action = "List", productPage = 1 }
                        );
                    routes.MapRoute(
                        name: null,
                        template: "",
                        defaults: new { Controller = "Product", action = "List", productPage = 1 }
                        );
                    routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
                });
                
                SeedData.EnsurePopulated(app);
            }
             
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            
        }
    }
}
