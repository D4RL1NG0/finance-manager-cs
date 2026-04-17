using Microsoft.EntityFrameworkCore;
namespace teste1;

public class AppDbContext: DbContext
{
    public DbSet<Transactions> Transactions {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = financemanager.db");
    }
}