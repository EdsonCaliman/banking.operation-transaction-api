using Banking.Operation.Transaction.Domain.Transaction.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Transaction.Domain.Transaction.Dtos
{
    [ExcludeFromCodeCoverage]
    public class RequestTransactionDto
    {
        [Required(ErrorMessage = "Type is mandatory")]
        [EnumDataTypeAttribute(typeof(TransactionType))]
        public string Type { get; set; }
        [Required(ErrorMessage = "Value is mandatory")]
        [Range(0.1, 10000, ErrorMessage = "Value must be between 0.1 and 10000")]
        public decimal Value { get; set; }
    }
}
