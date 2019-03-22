using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoccerManagementSystem.Models;

namespace SoccerManagementSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) // ctor tab tab
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Configuration["Data:SoccerManagementSystem:ConnectionString"]));
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SoccerManagementSystem;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddTransient<IRepository, EFRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes => routes.MapRoute(name: null, template: "{controller}/{action}/", defaults: new { controller = "Home", action = "Index" }));

            SeedData.EnsurePopulated(app);
        }
    }
}
