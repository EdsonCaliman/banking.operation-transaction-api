using Banking.Operation.Transaction.Domain.Transaction.Parameters;
using Banking.Operation.Transaction.Domain.Transaction.Services;
using Flurl.Http.Testing;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Tests.Transaction.Services
{
    public class ClientServiceTest
    {
        private IClientService _clientService;
        private ClientApiParameters _clientApiParameters;

        [SetUp]
        public void SetUp()
        {
            _clientApiParameters = new ClientApiParameters();

            _clientService = new ClientService(_clientApiParameters);
        }

        [Test]
        public async Task ShouldGetOneWithSuccess()
        {
            var Id = Guid.NewGuid();
            _clientApiParameters.Url = "https://api.com";

            using var httpTest = new HttpTest();

            httpTest.RespondWith($"{{'Id':'{Id}', 'Name': 'Test' }}", 200);

            var client = await _clientService.GetOne(Id);

            Assert.AreEqual("Test", client.Name);
            Assert.AreEqual(Id, client.Id);
            httpTest.ShouldHaveCalled("https://api.com/*")
                .WithVerb(HttpMethod.Get);
        }
    }
}
