using FundAggregator.Portfolio.Contracts.Interfaces;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Contracts.Commands
{
    public class CreatePortfolio: ICommand, IPortfolioMessage
    {
        public Guid PortfolioId { get; set; }
        public string Name { get; set; }
    }
}
