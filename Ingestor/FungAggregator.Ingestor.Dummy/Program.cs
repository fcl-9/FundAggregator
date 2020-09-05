using FundAggregator.Portfolio.Contracts.Commands;
using FundAggregator.Portfolio.Contracts.Events;
using NServiceBus;
using System;

namespace FungAggregator.Ingestor.Dummy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "FundAggregator.Ingestor.Service";
            var endpointConfiguration = new EndpointConfiguration("FundAggregator.Ingestor.Service");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var routing = transport.Routing();

            routing.RouteToEndpoint(typeof(CreatePortfolio).Assembly, typeof(CreatePortfolio).Namespace, "FundAggregator.Portfolio.Service");
            routing.RouteToEndpoint(typeof(UpdatePortfolio).Assembly, typeof(UpdatePortfolio).Namespace, "FundAggregator.Portfolio.Service");

            var persistence = endpointConfiguration.UsePersistence<LearningPersistence>();


            var endpoint = Endpoint.Create(endpointConfiguration).GetAwaiter().GetResult();
            var endpointInstance = endpoint.Start().GetAwaiter().GetResult();
            while (true) {
                Console.WriteLine("Press any key to continue:");
                Console.ReadLine();
                var portfolioId = Guid.NewGuid();
                endpointInstance.Send(new CreatePortfolio() { PortfolioId = portfolioId }).GetAwaiter().GetResult();
                endpointInstance.Send(new UpdatePortfolio() { PortfolioId = portfolioId }).GetAwaiter().GetResult();
            }
            endpointInstance.Stop().GetAwaiter().GetResult();
           
        }
    }
}
