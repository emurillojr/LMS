using Library.Controllers;
using Library.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library
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
            // add framework services
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddScoped<IAsset, LibraryAssetService>(); //
            //services.AddScoped<ICheckout, CheckoutService>(); //
            services.AddScoped<IPatron, PatronService>(); //
            services.AddScoped<IBranch, LibraryBranchService>(); //
            //services.AddScoped<IAll, AllService>();

            // added reference LibraryData project to Library
            //add DBContect on service collection
            services.AddDbContext<LibraryContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("LibraryConnection")));  // pass connection strong from appsetting.json
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Routes  telling app how to do its routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",  // default route  controller name / action result / id
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
