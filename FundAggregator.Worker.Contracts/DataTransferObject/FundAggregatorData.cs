using System;
using System.Collections.Generic;

namespace FundAggregator.Worker.Shared.DataTransferObject
{
    public class FundAggregatorData
    {
        public string FundName { get; set; }
        
        // Fund Identifiers
        public string Sedol { get; set; }
        public string Apir { get; set; }
        public string Isin { get; set; }

        // Compostion
        Dictionary<string, decimal> TopTenGeography { get; }
        Dictionary<string, decimal> TopTenSectors { get; }
        
        public FundAggregatorData() {
            TopTenGeography = new Dictionary<string, decimal>();
            TopTenSectors = new Dictionary<string, decimal>();
        }
    }
}
