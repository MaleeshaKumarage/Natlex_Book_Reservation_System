using Application;
using Application.Abstraction;
using Application.Book.CommandHandler;
using Application.Book.Commands;
using Infrastructure;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var cs = builder.Configuration.GetConnectionString("Default");
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

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
