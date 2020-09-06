using System;
using System.Collections.Generic;

namespace FundAggregator.Worker.Shared.DataTransferObject
{
    public class FundAggregatorData
    {
        public string FundName { get; set; }
        public string Issuer { get; set; }

        // Fund Identifiers
        public FundIdentifiers FundIdentifiders { get; set; }

        // Compostion
        public Dictionary<string, decimal> TopTenGeography { get; }
        public Dictionary<string, decimal> TopTenSectors { get; }
        public DateTime CreatedDate { get; set;  }
        public DateTime ModifiedDate { get; set; }

        public FundAggregatorData() {
            TopTenGeography = new Dictionary<string, decimal>();
            TopTenSectors = new Dictionary<string, decimal>();
        }
    }
}
