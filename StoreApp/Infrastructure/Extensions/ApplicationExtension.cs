using Repositories;
using Microsoft.EntityFrameworkCore;
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
            app.UseRequestLocalization(options=>
            {
                options.AddSupportedCultures("tr-TR","en-US","fr-Fr")
                        .AddSupportedUICultures("tr-TR","en-US","fr-Fr")
                        .SetDefaultCulture("tr-TR");
                /*learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/supported-culture-codes*/
            });
        }
    }
}