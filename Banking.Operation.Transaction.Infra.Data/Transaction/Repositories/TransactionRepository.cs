using Banking.Operation.Transaction.Domain.Transaction.Entities;
using Banking.Operation.Transaction.Domain.Transaction.Repositories;
using Banking.Operation.Transaction.Infra.Data.Repositories;

namespace Banking.Operation.Transaction.Infra.Data.Transaction.Repositories
{
    public class TransactionRepository : BaseRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context)
            : base(context) { }
    }
}
