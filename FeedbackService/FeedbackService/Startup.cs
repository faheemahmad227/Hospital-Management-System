using FeedbackService.Model;
using FeedbackService.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackService
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
            services.AddCors();
            services.AddControllers();
            var connectionstring = Configuration.GetConnectionString("TrainerManagementConnection");
            services.AddDbContext<FeedbackDbContext>(setup => setup.UseSqlServer(Configuration.GetConnectionString("connectionstring")));
            services.AddScoped<IFeedbackService<DoctorFeedback>, FeedbackService<DoctorFeedback>>();
            services.AddScoped<IFeedbackService<FacilityFeedback>, FeedbackService<FacilityFeedback>>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Feedback API",
                Description = "Feedback api for Hospital Management System"
            }));

            string key = Configuration["JwtSettings:Key"];
            string issuer = Configuration["JwtSettings:Issuer"];
            string audience = Configuration["JwtSettings:Audience"];
            int durationInMinutes = int.Parse(Configuration["JwtSettings:DurationInMinutes"]);

            byte[] keyBytes = System.Text.Encoding.ASCII.GetBytes(key);
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);

            services.AddAuthentication(setup =>
            {
                setup.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(setup => setup.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = audience,
                ValidIssuer = issuer,
                IssuerSigningKey = securityKey
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Feedback API"));
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
