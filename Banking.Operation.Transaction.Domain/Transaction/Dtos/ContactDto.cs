using System;

namespace Banking.Operation.Transaction.Domain.Transaction.Dtos
{
    public class ContactDto
    {
        public ContactDto()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ClientDto Client { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
