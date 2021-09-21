using Banking.Operation.Transaction.Domain.Abstractions.Repositories;
using Banking.Operation.Transaction.Domain.Transaction.Entities;

namespace Banking.Operation.Transaction.Domain.Transaction.Repositories
{
    public interface ITransactionRepository : IBaseRepository<TransactionEntity>
    {
    }
}
