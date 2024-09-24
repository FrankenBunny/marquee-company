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
            new User { Id = Guid.NewGuid(), Name = "Adam", Username = "Adam", PasswordHash = "123", Email = "adam@test.com" },
            new User { Id = Guid.NewGuid(), Name = "Benjamin", Username = "Benjamin", PasswordHash = "123", Email = "benjamin@test.com" },
            new User { Id = Guid.NewGuid(), Name = "Carl", Username = "Carl", PasswordHash = "123", Email = "carl@test.com" }
            );
        }

        databaseContext.SaveChanges();
    }
}