using Banking.Operation.Transaction.Domain.Transaction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banking.Operation.Transaction.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<TransactionEntity> Transactions { get; set; }
    }
}
