using ProductApp.Application;
using ProductApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationRegistiration();
builder.Services.AddPersistenceServices();
builder.Services.AddControllers(); // API controller'larını tanımlar

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error"); // opsiyonel
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // API controller'larını eşler

app.Run();
