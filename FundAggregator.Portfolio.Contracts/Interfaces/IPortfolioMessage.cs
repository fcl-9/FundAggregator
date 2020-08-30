using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Contracts.Interfaces
{
    public interface IPortfolioMessage
    {
        public Guid PortfolioId { get; set; }
    }
}
