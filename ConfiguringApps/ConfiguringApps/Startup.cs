using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfiguringApps
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseMiddleware<ErrorMiddleware>();
                if ((Configuration.GetSection("ShortCircuitMiddleware")?.GetValue<bool>("EnableBrowserShortCircuit")).Value)
                {
                    app.UseMiddleware<BrowserTypeMiddleware>();
                    app.UseMiddleware<ShortCircuitMiddleware>();
                }

                app.UseMiddleware<ContentMiddleware>();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }
            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
