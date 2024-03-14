using AppointmentBillingService.Models;
using AppointmentBillingService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace AppointmentBillingService
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
            services.AddCors();
            services.AddControllers();
            var connectionstring = Configuration.GetConnectionString("connectionstring");
            services.AddDbContext<AppointmentDbContext>(setup => setup.UseSqlServer(connectionstring));
            services.AddScoped<IRepository<Appointment>, GenericRepository<Appointment>>();
            services.AddScoped<IRepository<Billing>, GenericRepository<Billing>>();
            services.AddScoped<IRepository<FacilityAppointment>, GenericRepository<FacilityAppointment>>();
            services.AddScoped<IRepository<AmbulanceService>, GenericRepository<AmbulanceService>>();
            services.AddScoped<IRepository<PhysiotherapyService>, GenericRepository<PhysiotherapyService>>();
            services.AddScoped<IRepository<LaboratoryService>, GenericRepository<LaboratoryService>>();
            services.AddScoped<IRepository<ECGService>, GenericRepository<ECGService>>();
            services.AddScoped<IRepository<RadiologyService>, GenericRepository<RadiologyService>>();
            services.AddScoped<IRepository<Consultation>, GenericRepository<Consultation>>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BookAppointment API",
                Description = "BookAppointment api for Hospital Management System"
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital Management API"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(setup => setup.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
