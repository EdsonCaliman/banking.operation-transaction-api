using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using Banking.Operation.Transaction.Domain.Transaction.Parameters;
using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Domain.Transaction.Services
{
    public class ClientService : IClientService
    {
        private const string clientRelativeUrl = "/clients/{0}";
        private readonly ClientApiParameters _clientApiParameters;

        public ClientService(ClientApiParameters clientApiParameters)
        {
            _clientApiParameters = clientApiParameters;
        }

        public async Task<ClientDto> GetOne(Guid id)
        {
            var finalClientRelativeUrl = string.Format(clientRelativeUrl, id);

            return await _clientApiParameters
                .Url
                .AppendPathSegment(finalClientRelativeUrl)
                .GetJsonAsync<ClientDto>();
        }
    }
}
