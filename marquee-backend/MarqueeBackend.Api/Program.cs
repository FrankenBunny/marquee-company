using dotnetFullstack.Api.Services;
using dotnetFullstack.DataService.Data;
using dotnetFullstack.DataService.Repositories;
using dotnetFullstack.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString)); // Ensure UseSqlServer is recognized

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

    DatabaseMigrationService.DatabaseMigrationServiceInitialization(app);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
