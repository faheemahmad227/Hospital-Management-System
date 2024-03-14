using HospitalManagementUI.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI
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
            services.AddControllersWithViews();
            var api1url = Configuration["ApiAddresses:AuthenticationAPI"];
            var api2url = Configuration["ApiAddresses:HospitalManagementAPI"];
            var api3url = Configuration["ApiAddresses:BookingAppointmentAPI"];
            var api4url = Configuration["ApiAddresses:FeedbackAPI"];
            

            services.AddHttpClient("AuthenticationAPI", setup => setup.BaseAddress = new Uri(api1url));
            services.AddHttpClient("HospitalManagementAPI", setup => setup.BaseAddress = new Uri(api2url));
            services.AddHttpClient("BookingAppointmentAPI", setup => setup.BaseAddress = new Uri(api3url));
            services.AddHttpClient("FeedbackAPI", setup => setup.BaseAddress = new Uri(api4url));

            services.AddScoped(typeof(UserServices));
            services.AddScoped(typeof(HospitalServices));
            services.AddScoped(typeof(FacilityServices));
            services.AddScoped(typeof(UsersAccessServices));
            services.AddScoped(typeof(AppointmentServices));
            services.AddScoped(typeof(FeedbackServices));
            services.AddSession();
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
            }
            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
