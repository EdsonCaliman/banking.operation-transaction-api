using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using Banking.Operation.Transaction.Domain.Transaction.Parameters;
using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Domain.Transaction.Services
{
    public class ContactService : IContactService
    {
        private const string contactRelativeUrl = "/{0}/contacts/{1}";
        private readonly ContactApiParameters _contactApiParameters;

        public ContactService(ContactApiParameters contactApiParameters)
        {
            _contactApiParameters = contactApiParameters;
        }

        public async Task<ContactDto> GetOne(Guid clientid, Guid id)
        {
            var finalContactRelativeUrl = string.Format(contactRelativeUrl, clientid, id);

            return await _contactApiParameters
                .Url
                .AppendPathSegment(finalContactRelativeUrl)
                .GetJsonAsync<ContactDto>();
        }
    }
}
