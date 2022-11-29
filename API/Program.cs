using API.Painting.Domain.Repositories;
using API.Painting.Domain.Services;
using API.Painting.Repositories;
using API.Painting.Services;
using API.Shared.Domain.Repositories;
using API.Shared.Persistence.Contexts;
using API.Shared.Persistence.Repositories;
using API.Training.Domain.Repositories;
using API.Training.Domain.Services;
using API.Training.Repositories;
using API.Training.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
var databaseConnectionString = builder.Configuration.GetConnectionString("MySQLConnection");

builder.Services.AddDbContext<AppDbContext>(
    opts =>
        opts.UseMySQL(databaseConnectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
);


// Lowercase routes
builder.Services.AddRouting(opts => opts.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IProviderService, ProviderService>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(API.Painting.Mapping.ModelToResourceProfile),
    typeof(API.Painting.Mapping.ResourceToModelProfile),
    typeof(API.Training.Mapping.ModelToResourceProfile),
    typeof(API.Training.Mapping.ResourceToModelProfile)
);

var app = builder.Build();

// Validation for Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    // Create-drop method
    if (context.Database.CanConnect())
        context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("v1/swagger.json", "v1");
        opts.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
    app.Run();
else
    app.Run("http://localhost:7070");