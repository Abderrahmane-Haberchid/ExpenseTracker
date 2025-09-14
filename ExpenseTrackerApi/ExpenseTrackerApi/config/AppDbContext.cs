using Microsoft.EntityFrameworkCore;

namespace DefaultNamespace
{
    public class AppDbContext : DbContext
    {
        // These should be public properties so EF Core can access them
        public DbSet<TransactionModel> Transactions { get; set; }

        // Constructor should accept DbContextOptions<AppDbContext>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}