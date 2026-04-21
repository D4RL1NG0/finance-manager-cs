using FinanceAPI.Data;
using FinanceAPI.Models;
using FinanceAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite("Data Source=financemanager.db"));

builder.Services.AddScoped<Finance_Manager>();

var app = builder.Build();

app.MapControllers();

app.Run();