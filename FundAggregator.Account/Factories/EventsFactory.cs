using FundAggregator.Portfolio.Contracts.Events;
using FundAggregator.Portfolio.Contracts.Interfaces;
using System;

namespace FundAggregator.Portfolio.Service.Factories
{
    internal class EventsFactory : IEventsFactory
    {
        public CreatedPortfolio CreatedCreatedPortfolioEvent(Guid portfolioId)
        {
            return new CreatedPortfolio()
            {
                PortfolioId = portfolioId,
                CreatedDate = DateTime.UtcNow
            };
        }

        public UpdatedPortfolio CreateUpdatedPortfolioEvent(Guid portfolioId)
        {
            return new UpdatedPortfolio()
            {
                PortfolioId = portfolioId,
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}
