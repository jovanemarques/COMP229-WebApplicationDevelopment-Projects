using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace URLsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(
                routes =>
                {
                    //routes.MapRoute("", "Shop/{action}", new { controller = "Home", action = "Index" });
                    //routes.MapRoute(name: "",
                    //               template: "X{controller}/{action}");
                    //routes.MapRoute(name: "default",
                    //                template: "{controller=Home}/{action=Index}"
                    //                /*,defaults: new { action = "Index" }*/);
                    //routes.MapRoute(name: "",
                    //                template: "Public/{controller=Home}/{action=Index}"
                    //                /*,defaults: new { action = "Index" }*/);
                    //routes.MapRoute(name: "",
                    //                template: "{controller=Home}/{action=Index}/{id?}/{*allElse}",
                    //                defaults: new { controller = "Home", action = "Index" },
                    //                constraints: new { id = new IntRouteConstraint() }
                    //                );
                    routes.MapRoute(name: "",
                                    template: "{controller:regex(^h.*)=Home}/{action=Index}/{id?}");
                }
            );
        }
    }
}
