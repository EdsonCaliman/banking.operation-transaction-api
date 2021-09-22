using AutoFixture;
using Banking.Operation.Transaction.Domain.Abstractions.Exceptions;
using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using Banking.Operation.Transaction.Domain.Transaction.Entities;
using Banking.Operation.Transaction.Domain.Transaction.Repositories;
using Banking.Operation.Transaction.Domain.Transaction.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Tests.Transaction.Services
{
    public class TransactionServiceTest
    {
        private ITransactionService _transactionService;
        private Mock<ITransactionRepository> _transactionRepository;
        private Mock<IClientService> _clientService;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _transactionRepository = new Mock<ITransactionRepository>();
            _clientService = new Mock<IClientService>();
            _fixture = new Fixture();

            _transactionService = new TransactionService(_transactionRepository.Object, _clientService.Object);
        }

        [Test]
        public async Task ShouldReturnOneTransaction()
        {
            var client = _fixture.Create<ClientDto>();
            var transaction = _fixture.Create<TransactionEntity>();
            var transactionId = Guid.NewGuid();
            _clientService.Setup(c => c.GetOne(client.Id)).Returns(Task.FromResult(client));
            _transactionRepository.Setup(c => c.FindOne(It.IsAny<Expression<Func<TransactionEntity, bool>>>())).Returns(Task.FromResult(transaction));

            var transactionDto = await _transactionService.GetOne(client.Id, transactionId);

            Assert.IsNotNull(transactionDto);
        }

        [Test]
        public void ShouldNotReturnOneTransactionWhenInvalidClient()
        {
            var client = _fixture.Create<ClientDto>();
            var transactionId = Guid.NewGuid();

            Func<Task> action = async () => { await _transactionService.GetOne(client.Id, transactionId); };
            action.Should().ThrowAsync<BussinessException>();
        }

        [Test]
        public async Task ShouldReturnAllTransactions()
        {
            var client = _fixture.Create<ClientDto>();
            _clientService.Setup(c => c.GetOne(client.Id)).Returns(Task.FromResult(client));
            var transactionList = new List<TransactionEntity> {
                new TransactionEntity { ClientId = client.Id, Value = 10 },
                new TransactionEntity { ClientId = client.Id, Value = 15 },
            }.AsQueryable();
            _transactionRepository.Setup(c => c.Get()).Returns(transactionList);
            
            var transactionListDto = await _transactionService.GetAll(client.Id);

            Assert.IsNotNull(transactionListDto);
            Assert.AreEqual(2, transactionListDto.Count);
        }

        [Test]
        public async Task ShouldSaveTransaction()
        {
            var client = _fixture.Create<ClientDto>();
            var requestTransactionDto = new RequestTransactionDto { Type = "Credit", Value = 10 };
            _clientService.Setup(c => c.GetOne(client.Id)).Returns(Task.FromResult(client));

            var transactionDto = await _transactionService.Save(client.Id, requestTransactionDto);

            Assert.IsNotNull(transactionDto);
            _transactionRepository.Verify(c => c.Add(It.IsAny<TransactionEntity>()));
        }
    }
}
