using FundAggregator.Portfolio.Contracts.Interfaces;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Contracts.Events
{
    public class CreatedPortfolio : IEvent, IPortfolioMessage
    {
        public Guid PortfolioId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
