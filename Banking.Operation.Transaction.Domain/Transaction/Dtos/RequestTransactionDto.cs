using Banking.Operation.Transaction.Domain.Transaction.Enums;
using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Transaction.Domain.Transaction.Dtos
{
    public class RequestTransactionDto
    {
        [Required(ErrorMessage = "Type is mandatory")]
        [EnumDataTypeAttribute(typeof(TransactionType))]
        public string Type { get; set; }
        [Required(ErrorMessage = "Value is mandatory")]
        [Range(0, 10000, ErrorMessage = "Value must be between 0 and 10000")]
        public decimal Value { get; set; }
    }
}
