using Microsoft.EntityFrameworkCore;
using marquee_backend.Data;
using marquee_backend.Models.Inventory;
using marquee_backend.Models.Auth;

namespace MarqueeBackend.Api.Services;

public class DatabaseMigrationService
{
    public static void DatabaseMigrationServiceInitialization(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<MarqueeDatabaseContext>();

            // Apply migrations
            context.Database.Migrate();

            // Seed data
            SeedDataOnCreation(context);
        }
    }

    protected static void SeedDataOnCreation (MarqueeDatabaseContext databaseContext)
    {
        if (!databaseContext.RentableCategories.Any())
        {
            databaseContext.RentableCategories.AddRange(
                new RentableCategory { Id = Guid.NewGuid(), Title = "Tents", Description = "This is a sample category" },
                new RentableCategory { Id = Guid.NewGuid(), Title = "Roofs", Description = "This is a sample category" },
                new RentableCategory { Id = Guid.NewGuid(), Title = "Walls", Description = "This is a sample category" }
            );
        }

        if (!databaseContext.Users.Any())
        {
            databaseContext.Users.AddRange(
            new User { Id = Guid.NewGuid(), Name = "Tents", Username = "", PasswordHash = "123", Email = "This is a sample category" },
            new User { Id = Guid.NewGuid(), Name = "Roofs", Username = "", PasswordHash = "123", Email = "This is a sample category" },
            new User { Id = Guid.NewGuid(), Name = "Walls", Username = "", PasswordHash = "123", Email = "This is a sample category" }
            );
        }

        databaseContext.SaveChanges();
    }
}