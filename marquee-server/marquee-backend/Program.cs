using marquee_backend.Data;
using Microsoft.EntityFrameworkCore;
using MarqueeBackend.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5019") // Adjust if you have multiple origins
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); // Allow credentials if needed (e.g., cookies)
        });
});
// Database context dependency injection
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");


var connectionString = $"Server={dbHost};Database={dbName}; User ID=SA; Password={dbPassword}; TrustServerCertificate=true;";
Console.WriteLine(connectionString);
builder.Services.AddDbContext<MarqueeDatabaseContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//Add application database context
//builder.Services.AddDbContext<MarqueeDatabaseContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
//});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


    DatabaseMigrationService.DatabaseMigrationServiceInitialization(app);
}

// CORS
app.UseCors(MyAllowSpecificOrigins);

// HTTPS redirection (recommended for production)
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
