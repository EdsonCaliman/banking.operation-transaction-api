using Banking.Operation.Transaction.Domain.Transaction.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Transaction.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<TransactionEntity> Transactions { get; set; }
    }
}
