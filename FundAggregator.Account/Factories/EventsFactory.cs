using FundAggregator.Portfolio.Contracts.Events;
using FundAggregator.Portfolio.Contracts.Interfaces;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Factories
{
    internal class EventsFactory : IEventsFactory
    {
        public CreatedPortfolio CreatedCreatedPortfolioEvent(Guid portfolioId)
        {
            return new CreatedPortfolio()
            {
                PortfolioId = portfolioId
            };
        }

        public UpdatedPortfolio CreateUpdatedPortfolioEvent(Guid portfolioId)
        {
            return new UpdatedPortfolio()
            {
                PortfolioId = portfolioId
            };
        }
    }
}
