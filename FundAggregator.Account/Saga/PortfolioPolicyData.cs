using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Saga
{
    public  class PortfolioPolicyData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        public Guid PortfolioId { get; set; }
    }
}
