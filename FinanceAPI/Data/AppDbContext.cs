using Microsoft.EntityFrameworkCore;
using FinanceAPI.Models;
namespace FinanceAPI.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {
        
    }
    public DbSet<Transactions> Transactions {get; set;}

   
}