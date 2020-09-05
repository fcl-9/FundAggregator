using FundAggregator.Portfolio.Contracts.Model;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Service.Saga
{
    public  class PortfolioPolicyData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        public Guid PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public IList<Investment> Investments { get; set; } = new List<Investment>();
    }
}
