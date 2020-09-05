using FundAggregator.Configuration.NServiceBus;
using FundAggregator.Portfolio.Contracts.Interfaces;
using FundAggregator.Portfolio.Infrastructure.Context;
using FundAggregator.Portfolio.Infrastructure.Interfaces;
using FundAggregator.Portfolio.Infrastructure.Repository;
using FundAggregator.Portfolio.Service.Factories;
using FundAggregator.Portfolio.Service.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace FundAggregator.Portfolio.Service
{
    partial class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, container )=> {
                container.AddSingleton<IEventsFactory, EventsFactory>();
                container.AddScoped<IPortfolioHistoryRepository, PortfolioHistoryRepository>();
                container.AddDbContext<PortfolioHistoryContext>(options => options.UseSqlServer(context.Configuration.GetValue<string>(ConfigurationConstants.HistoryConnectionString),
                    b => b.MigrationsAssembly("FundAggregator.Portfolio.Service"))); ;
            })
            .UseNServiceBus(context => {
                var nServiceBusConfigurations = new NServiceBusSettings()
                {
                    EndpointName = context.Configuration.GetValue<string>(ConfigurationConstants.ServiceName),
                    PersistenceConnectionString = context.Configuration.GetValue<string>(ConfigurationConstants.PersistenceConnectionString)
                };
                var endpointConfiguration = NServiceBusConfiguration.ConfigureEndpoint(nServiceBusConfigurations);
                return endpointConfiguration;
            });
    }
}
