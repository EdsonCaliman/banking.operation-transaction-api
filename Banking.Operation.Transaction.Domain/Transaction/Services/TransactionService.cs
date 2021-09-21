using Banking.Operation.Transaction.Domain.Abstractions.Exceptions;
using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using Banking.Operation.Transaction.Domain.Transaction.Entities;
using Banking.Operation.Transaction.Domain.Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Domain.Transaction.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IClientService _clientService;
        private readonly IContactService _contactService;

        public TransactionService(
            ITransactionRepository transactionRepository, 
            IClientService clientService, 
            IContactService contactService)
        {
            _transactionRepository = transactionRepository;
            _clientService = clientService;
            _contactService = contactService;
        }

        public async Task<List<ResponseTransactionDto>> GetAll(Guid clientid)
        {
            await ValidateClient(clientid);

            var queryables = _transactionRepository.Get();

            var transactionList = queryables.Where(c => c.ClientId == clientid);

            return transactionList.Select(c => new ResponseTransactionDto(c)).ToList();
        }

        public async Task<ResponseTransactionDto> GetOne(Guid clientid, Guid id)
        {
            await ValidateClient(clientid);

            var transactionEntity = await _transactionRepository.FindOne(c => c.ClientId == clientid && c.Id == id);

            return new ResponseTransactionDto(transactionEntity);
        }

        public async Task<ResponseTransactionDto> Save(Guid clientid, RequestTransactionDto transaction)
        {
            var client = await ValidateClient(clientid);

            var contact = await ValidateContact(client, transaction.ContactId);

            var transactionEntity = new TransactionEntity(client, contact, transaction.Value);

            await _transactionRepository.Add(transactionEntity);

            return new ResponseTransactionDto(transactionEntity);
        }

        private async Task<ClientDto> ValidateClient(Guid clientid)
        {
            var client = await _clientService.GetOne(clientid);

            if (client is null)
            {
                throw new BussinessException("Operation not performed", "Client not registered");
            }

            return client;
        }

        private async Task<ContactDto> ValidateContact(ClientDto client, Guid contactId)
        {
            var contact = await _contactService.GetOne(client.Id, contactId);

            if (contact is null)
            {
                throw new BussinessException("Operation not performed", "Contact not registered");
            }

            return contact;
        }
    }
}
