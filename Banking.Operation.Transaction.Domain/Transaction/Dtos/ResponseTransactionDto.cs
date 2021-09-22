using Banking.Operation.Transaction.Domain.Transaction.Entities;
using System;

namespace Banking.Operation.Transaction.Domain.Transaction.Dtos
{
    public class ResponseTransactionDto
    {
        public ResponseTransactionDto(TransactionEntity entity)
        {
            Id = entity.Id;
            Type = entity.Type.ToString();
            Value = entity.Value;
            CreatedAt = entity.CreatedAt;
            CreatedBy = entity.CreatedBy;
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
