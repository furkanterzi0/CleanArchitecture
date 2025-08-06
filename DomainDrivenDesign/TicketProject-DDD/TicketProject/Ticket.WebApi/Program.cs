using Ticket.Application.DTOs;
using Ticket.Application.Interfaces;
using Ticket.Application.Validators;
using AutoMapper;
using Ticket.Common.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Ticket.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Ticket.Application.DTOs;
using Ticket.Application.Interfaces;
using Ticket.Application.Validators;
using Ticket.Infrastructure.Context;
using Ticket.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Host.UseSerilog((ctx, config) =>
    config.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// Add services
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TicketDbContext>(options =>
options.UseInMemoryDatabase("TicketDb"));

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IValidator<TicketDTO>, TicketDtoValidator>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddHealthChecks()
    .AddDbContextCheck<TicketDbContext>();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
