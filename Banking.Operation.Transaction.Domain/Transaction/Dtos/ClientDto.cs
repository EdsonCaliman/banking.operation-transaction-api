using System;

namespace Banking.Operation.Transaction.Domain.Transaction.Dtos
{
    public class ClientDto
    {
        public ClientDto()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
