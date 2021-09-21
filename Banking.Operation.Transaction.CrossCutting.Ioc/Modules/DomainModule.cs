using Banking.Operation.Transaction.Domain.Transaction.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Operation.Transaction.CrossCutting.Ioc.Modules
{
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
