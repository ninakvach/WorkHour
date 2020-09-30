using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WorkHour.Business.DataAccess.Abstract;
using WorkHour.Business.DataAccess.Concrete.EntityFramework;
using WorkHour.Business.SessionStorage;
using WorkHour.Data.Models;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
namespace WorkHour.Pr
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.    "   
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDbContext<WorkHourContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUnitofWork, EfUnitofWork>();
            services.AddTransient<WorkHourContext, WorkHourContext>();
           // services.AddScoped<IRepository, EFGenericRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {

            
            app.UseSession();
            SessionStorage.Configure(app.ApplicationServices
                      .GetRequiredService<IHttpContextAccessor>());
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
