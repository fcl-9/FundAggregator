using FundAggregator.Portfolio.Contracts.Interfaces;
using FundAggregator.Portfolio.Contracts.Model;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Contracts.Commands
{
    public class UpdatePortfolio: ICommand, IPortfolioMessage
    {
        public Guid PortfolioId { get; set; }
        public List<Investment> NewInvestmenets { get; set; }
    }
}
