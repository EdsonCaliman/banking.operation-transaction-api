using Banking.Operation.Transaction.Domain.Transaction.Entities;
using Banking.Operation.Transaction.Domain.Transaction.Repositories;
using Banking.Operation.Transaction.Infra.Data.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Transaction.Infra.Data.Transaction.Repositories
{
    [ExcludeFromCodeCoverage]
    public class TransactionRepository : BaseRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context)
            : base(context) { }
    }
}
