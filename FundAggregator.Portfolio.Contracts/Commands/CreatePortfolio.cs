using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Contracts.Commands
{
    public class CreatePortfolio
    {
        public Guid PortfolioId { get; set; }
        public string Name { get; set; }
    }
}
