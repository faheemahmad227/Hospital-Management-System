using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSystem.Models
{
    public class AppSeedAdmin
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AppSeedAdmin(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedUsersAsync()
        {
            await roleManager.CreateAsync(new IdentityRole { Name = "SystemAdmin" });
            if (!userManager.Users.Any())
            {
                var SystemAdmin = new ApplicationUser
                {
                    FullName = "Harsh Kumar",
                    UserName = "harshkumar@gmail.com",
                    FirstName = "Harsh",
                    LastName = "Kumar",
                    Age = 26,
                    Address = "4th Cross,Bangalore",
                    Gender = "Male",
                    PhoneNumber = "9867457677",
                    Email = "harshkumar@gmail.com",
                    PasswordHash = "Harsh@123"
                };

                await userManager.CreateAsync(SystemAdmin, "Harsh@123");

                await userManager.AddToRoleAsync(SystemAdmin, "SystemAdmin");
            }

        }
    }
}
