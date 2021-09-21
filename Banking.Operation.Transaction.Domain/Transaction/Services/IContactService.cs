using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Domain.Transaction.Services
{
    public interface IContactService
    {
        Task<ContactDto> GetOne(Guid clientid, Guid id);
    }
}
