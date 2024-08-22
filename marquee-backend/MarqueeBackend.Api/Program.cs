using MarqueeBackend.DataService.Data;
using MarqueeBackend.DataService.Repositories;
using MarqueeBackend.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// SqlServer
//var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

// SqlServer
// builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString)); // Ensure UseSqlServer is recognized

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // SqlServer
    //DatabaseMigrationService.DatabaseMigrationServiceInitialization(app);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
