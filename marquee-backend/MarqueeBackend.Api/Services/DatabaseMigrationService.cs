using dotnetFullstack.DataService.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetFullstack.Api.Services;

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
