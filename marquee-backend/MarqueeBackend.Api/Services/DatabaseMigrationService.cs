using MarqueeBackend.DataService.Data;
using Microsoft.EntityFrameworkCore;

namespace MarqueeBackend.Api.Services;

public class DatabaseMigrationService
{
    public static void DatabaseMigrationServiceInitialization(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
        }
    }
}
