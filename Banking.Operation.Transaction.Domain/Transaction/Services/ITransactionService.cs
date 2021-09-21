using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Domain.Transaction.Services
{
    public interface ITransactionService
    {
        Task<List<ResponseTransactionDto>> GetAll(Guid clientid);
        Task<ResponseTransactionDto> GetOne(Guid clientid, Guid id);
        Task<ResponseTransactionDto> Save(Guid clientid, RequestTransactionDto transaction);
    }
}
