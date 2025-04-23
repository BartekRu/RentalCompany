using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wypozyczalnia1.Models;

namespace Wypozyczalnia1.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAdmin(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Tworzenie roli admina jeśli nie istnieje
            string adminRole = "Admin";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // Sprawdź, czy admin istnieje
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.Users.FirstOrDefaultAsync(u => u.Email == adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    Profile = new UserProfile
                    {
                        FirstName = "Admin",
                        LastName = "Konto",
                        Address = "Centrum 1",
                        UserType = UserType.Gold
                    }
                };

                var result = await userManager.CreateAsync(adminUser, "Zaba2003!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }
        }
    }
}
