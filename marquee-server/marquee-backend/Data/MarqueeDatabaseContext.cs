using marquee_backend.Models.Auth;
using marquee_backend.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace marquee_backend.Data;

public class MarqueeDatabaseContext : DbContext
{

    public MarqueeDatabaseContext(DbContextOptions<MarqueeDatabaseContext> options)
        : base(options)
    {
        /*
        var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

        if(!dbCreator.CanConnect())
        {
            dbCreator.CreateAsync();
        }

        if (!dbCreator.HasTables())
        {
            dbCreator.CreateTablesAsync();
        }
        */
    }

    // Auth
    public DbSet<Role> Roles { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    // Inventory
    public DbSet<Rentable> Rentables { get; set; }

    public DbSet<Part> Parts { get; set; }  

    public DbSet<Item> Items { get; set; }

    public DbSet<RentableCategory> RentableCategories { get; set; }

    public DbSet<RentableTag> RentableTags{ get; set; }

    public DbSet<RentableTagRentable> RentableTagRentables{ get; set; } // Keeps track of rentables tags



//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=marquee-database;User Id=sa;Password=FrankenBunnyDevelops<1Databases;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Auth
        new RoleEntityTypeConfiguration().Configure(modelBuilder.Entity<Role>());
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        new UserRoleEntityTypeConfiguration().Configure(modelBuilder.Entity<UserRole>());

        // Inventory
        new RentableEntityTypeConfiguration().Configure(modelBuilder.Entity<Rentable>());
        new PartEntityTypeConfiguration().Configure(modelBuilder.Entity<Part>());
        new ItemEntityTypeConfiguration().Configure(modelBuilder.Entity<Item>());
        new RentableCategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<RentableCategory>());
        new RentableTagEntityTypeConfiguration().Configure(modelBuilder.Entity<RentableTag>());
        new RentableTagRentableEntityTypeConfiguration().Configure(modelBuilder.Entity<RentableTagRentable>());
    }
}
