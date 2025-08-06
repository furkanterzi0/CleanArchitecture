using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArchDemo.Application;
using OnionArchDemo.Application.Interfaces.Repositories;
using OnionArchDemo.Domain.Entities;
using OnionArchDemo.Persistence;
using OnionArchDemo.Persistence.Context;
using OnionArchDemo.Persistence.Repositories;
using OnionArchDemo.Persistence.Seed;



var builder = WebApplication.CreateBuilder(args);

// Controller ve Swagger Servisleri
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); 

// MediatR – Application Katmanındaki Handler'ları Tara
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationRegistiration();

// Uygulamayı Oluştur
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Seed(dbContext);
}

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
