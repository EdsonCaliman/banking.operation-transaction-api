using Banking.Operation.Transaction.Domain.Abstractions.Helpers;
using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using Banking.Operation.Transaction.Domain.Transaction.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Transaction.Domain.Transaction.Entities
{
    [ExcludeFromCodeCoverage]
    public class TransactionEntity
    {
        public TransactionEntity(ClientDto client, TransactionType type, decimal value)
        {
            ClientId = client.Id;
            Type = type;
            Value = value;
            CreatedAt = DateTime.Now;
            CreatedBy = CreatorHelper.GetEntityCreatorIdentity();
        }

        public TransactionEntity()
        {
        }

        [Key]
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
