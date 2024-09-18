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
            policy.WithOrigins("http://web.localhost:3000", "http://localhost:3000") 
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); // Allow credentials if needed (e.g., cookies)
        });
});

// Database context dependency injection
var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "postgres";
var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "marquee-database";
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres";

var connectionString = $"Host={dbHost};Port=5432;Username={dbUser};Password={dbPassword};Database={dbName}";
builder.Services.AddDbContext<MarqueeDatabaseContext>(options => 
{
    options.UseNpgsql(connectionString);
});

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
