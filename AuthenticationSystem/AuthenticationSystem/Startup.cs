using AuthenticationSystem.Models;
using AuthenticationSystem.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSystem
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
            services.AddControllers();
            services.AddScoped<IRepository<Patient>, PatientRepository<Patient>>();
            services.AddScoped<IRepository<Doctor>, DoctorRepository<Doctor>>();
            services.AddScoped<IRepository<Hospital>, HospitalAdminRepository<Hospital>>();
            services.AddScoped(typeof(AppSeedAdmin));
            services.AddDbContext<ApplicationDbContext>(setup =>
                                   setup.UseSqlServer(Configuration.GetConnectionString("con")));
            services.AddIdentity<ApplicationUser, IdentityRole>(setup =>
            {
                setup.Password.RequireDigit = true;
                //setup.SignIn.RequireConfirmedEmail = true;

                setup.Lockout.MaxFailedAccessAttempts = 5;
                setup.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "User Management api",
                Description = "User Management api for Hospital Management System"
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
