using Microsoft.EntityFrameworkCore;
using marquee_backend.Data;

namespace MarqueeBackend.Api.Services;

public class DatabaseMigrationService
{
    public static void DatabaseMigrationServiceInitialization(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<MarqueeDatabaseContext>().Database.Migrate();
        }
    }
}