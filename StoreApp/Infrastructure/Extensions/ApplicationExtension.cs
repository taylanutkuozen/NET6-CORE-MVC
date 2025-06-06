using Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                                      .ApplicationServices
                                      .CreateScope()
                                      .ServiceProvider
                                      .GetRequiredService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR", "en-US", "fr-Fr")
                        .AddSupportedUICultures("tr-TR", "en-US", "fr-Fr")
                        .SetDefaultCulture("tr-TR");
                /*learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/supported-culture-codes*/
            });
        }
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+1234";
            //UserManager
            UserManager<IdentityUser> userManager = app
                                            .ApplicationServices
                                            .CreateScope()
                                            .ServiceProvider
                                            .GetRequiredService<UserManager<IdentityUser>>();
            //RoleManager-->Admin'e butun rolleri vermek icin ihtiyac duyduk.
            RoleManager<IdentityRole> roleManager = app
                                                    .ApplicationServices
                                                    .CreateScope()
                                                    .ServiceProvider
                                                    .GetRequiredService<RoleManager<IdentityRole>>();
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            /*!!!Controller uzerinde olmadigimiz icin Task kullanmaya ihtiyac yoktur.*/
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "taylanutku.ozen@gmail.com",
                    PhoneNumber = "0123456789",
                    UserName = adminUser
                    //,EmailConfirmed=true
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception("Admin user could not created");
                var roleResult = await userManager.AddToRolesAsync(user,
                                 roleManager.Roles.Select(r => r.Name).ToList()
                /*new List<string>()
                {
                    "Admin",
                    "Editor",
                    "User"
                } --> statik bir yapi*/
                );
                if (!roleResult.Succeeded)
                    throw new Exception("System has problems with role definition for admin");    
            }
        }
    }
}