using Application;
using Application.Abstraction;
using Application.Book.CommandHandler;
using Application.Book.Commands;
using Infrastructure;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Presentation;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Debug()
    .WriteTo.File(Path.Combine(AppContext.BaseDirectory, "log.txt"),
        rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Natlex Book Reservation System API",
        Version = "v1.0",
        Description = "This API facilitates the management of a simple book reservation system, offering a set of endpoints to interact with book entities. The CRUD operations for the Book entity include creating, retrieving, updating, and deleting books. Each book is characterized by its unique identifier (id*), title*, author, and additional optional properties.\r\n\r\nAdditionally, the API provides functionality to reserve a book using a POST endpoint, requiring the book's id and a reservation comment as parameters. The reserved status and comment are stored within the system, and if a book is already reserved, the endpoint responds with an appropriate error status.\r\n\r\nFurthermore, the API offers a POST endpoint to remove the reserved status for a given book by passing its id as a parameter.",
        Contact = new OpenApiContact
        {
            Name = "Maleesha Kumarage",
            Email = "contactmaleesha93@gmail.com",
            Url = new Uri("https://maleeshakumarage.github.io/"),
        },
    });

});

builder.Services.AddDbContext<BookStoreDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "BookStore"));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IStatusHistoryRepository, StatusHistoryRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateBook)));
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
    dbContext.Database.EnsureCreated();
    dbContext.SeedData();
}
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

var app = builder.Build();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{

    c.DisplayRequestDuration();
    c.EnableFilter();
    c.InjectStylesheet("/swagger-custom.css");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
