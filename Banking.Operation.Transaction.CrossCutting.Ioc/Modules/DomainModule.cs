using Banking.Operation.Transaction.Domain.Transaction.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Transaction.CrossCutting.Ioc.Modules
{
    [ExcludeFromCodeCoverage]
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
