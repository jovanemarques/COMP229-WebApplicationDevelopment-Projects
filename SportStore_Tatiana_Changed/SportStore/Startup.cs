using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportStore.Models;

namespace SportStore
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
            //services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionStrings"]));
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SportsStore;Trusted_Connection=True;MultipleActiveResultSets=true"));
            
            //services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreIdentity:ConnectionStrings"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Identity;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IProductRepository, EntityFrameworkProductRepository>(); //FakeProductRepository deleted
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) // this is where I can access my services
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
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
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    productPage = 1
                }
                );


                routes.MapRoute(
                name: null,
                template: "{category}",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    productPage = 1
                }
                );

                routes.MapRoute(
                name: null,
                template: "",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    productPage = 1
                });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}


