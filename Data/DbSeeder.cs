using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BeFit.Web.Data
{
    public static class DbSeeder
    {
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string roleName = "Admin";
           
            string adminEmail = "szef@befit.pl";
            string adminPassword = "Mojefajnehaslo1!"; 
           
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(newAdmin, adminPassword);

                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, roleName);
                }
            }
            else
            {
                if (!await userManager.IsInRoleAsync(adminUser, roleName))
                {
                    await userManager.AddToRoleAsync(adminUser, roleName);
                }
            }
        }
    }
}