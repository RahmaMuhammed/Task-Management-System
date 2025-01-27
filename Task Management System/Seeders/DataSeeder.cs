using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models.Entites;

namespace Task_Management_System.Seeders
{
    public class DataSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>(); 

            if (await roleManager.Roles.AnyAsync()) return;

            string[] roles = { "Admin", "Manager", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = "admin@gmail.com";
            var adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    FName = "Rahma",
                    Email = adminEmail,
                    LName ="Mohamed",
                    PhoneNumber = "01147318810",
                    Address = "ElMatria",
                    UserName = adminEmail.Split('@')[0],
                    DOB = DateOnly.Parse("2002-05-28"),
                    IsAgree = true
                };
                var createResult = await userManager.CreateAsync(adminUser, adminPassword);
                if (createResult.Succeeded)
                {
                    var userId = adminUser.Id;

                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    foreach (var error in createResult.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
        }
    }
}
