using System;

namespace FundAggregator.Portfolio.Contracts.Model
{
    public class Investment
    {
        public Guid InvestmentId { get; set; }
        public Guid FundIdentifider { get; set; }
        public decimal Units { get; set; }
        public InvestmentStatus Status { get; set; }
    }
}
