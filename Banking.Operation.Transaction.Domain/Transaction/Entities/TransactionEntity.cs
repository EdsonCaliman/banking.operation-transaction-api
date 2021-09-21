﻿using Banking.Operation.Transaction.Domain.Abstractions.Helpers;
using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Transaction.Domain.Transaction.Entities
{
    public class TransactionEntity
    {
        public TransactionEntity(ClientDto client, ContactDto contact, decimal value)
        {
            ClientId = client.Id;
            ContactId = contact.Id;
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
        public Guid ContactId { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}