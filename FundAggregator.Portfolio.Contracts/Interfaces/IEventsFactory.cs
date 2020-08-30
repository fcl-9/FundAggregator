using FundAggregator.Portfolio.Contracts.Events;
using NServiceBus;
using System;

namespace FundAggregator.Portfolio.Contracts.Interfaces
{
    public interface IEventsFactory
    {
        CreatedPortfolio CreatedCreatedPortfolioEvent(Guid portfolioId);
        UpdatedPortfolio CreateUpdatedPortfolioEvent(Guid portfolioId);
    }
}