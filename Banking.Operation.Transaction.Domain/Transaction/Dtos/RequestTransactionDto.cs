using System;

namespace Banking.Operation.Transaction.Domain.Transaction.Dtos
{
    public class RequestTransactionDto
    {
        public Guid ContactId { get; set; }
        public decimal Value { get; set; }
    }
}
