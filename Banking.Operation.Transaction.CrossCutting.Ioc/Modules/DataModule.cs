﻿using Banking.Operation.Transaction.Domain.Transaction.Parameters;
using Banking.Operation.Transaction.Domain.Transaction.Repositories;
using Banking.Operation.Transaction.Infra.Data;
using Banking.Operation.Transaction.Infra.Data.Transaction.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Banking.Operation.Transaction.CrossCutting.Ioc.Modules
{

    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var clientParameters = configuration.GetSection("ClientApi").Get<ClientApiParameters>();
            services.AddSingleton(clientParameters);
            var contactParameters = configuration.GetSection("ContactApi").Get<ContactApiParameters>();
            services.AddSingleton(contactParameters);

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
