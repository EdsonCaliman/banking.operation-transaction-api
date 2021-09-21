using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Domain.Transaction.Services
{
    public interface IClientService
    {
        Task<ClientDto> GetOne(Guid id);
    }
}
