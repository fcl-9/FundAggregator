using FundAggregator.Portfolio.Contracts.Interfaces;
using FundAggregator.Portfolio.Infrastructure.Context;
using FundAggregator.Portfolio.Infrastructure.Interfaces;
using FundAggregator.Portfolio.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Infrastructure.Repository
{
    public class PortfolioHistoryRepository : IPortfolioHistoryRepository
    {
        private PortfolioHistoryContext _portfolioHistoryContext;

        public PortfolioHistoryRepository(PortfolioHistoryContext portfolioHistoryContext) {
            _portfolioHistoryContext = portfolioHistoryContext;
        }

        public void AddPortfolioHistory(Event evntToPersist)
        {
            _portfolioHistoryContext.Add(evntToPersist);
            _portfolioHistoryContext.SaveChanges();
        }
    }
}
