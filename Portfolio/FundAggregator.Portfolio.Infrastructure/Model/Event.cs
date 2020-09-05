using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Infrastructure.Model
{
    public class Event
    {
        public Guid EventId { get; set; }
        public Guid PortfolioId { get; set; }
        public string Payload { get; set; }
        public DateTime CreateDate {get; set;}
    }
}
