using FinanceAPI.Data;
using FinanceAPI.Models;
using FinanceAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite("Data Source=financemanager.db"));

builder.Services.AddScoped<Finance_Manager>();

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});

var app = builder.Build();

app.UseCors("PermitirTudo");

app.MapControllers();

app.Run();