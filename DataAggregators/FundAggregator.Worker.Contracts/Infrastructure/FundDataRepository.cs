using FundAggregator.Worker.Shared.DataTransferObject;
using FundAggregator.Worker.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundAggregator.Worker.Shared.Infrastructure
{
    public class FundDataRepository : IFundDataRepository
    {
        private static IList<FundAggregatorData> _fundDataStore;
        
        public FundDataRepository() {
            _fundDataStore = new List<FundAggregatorData>();
        }

        public void CreateFundData(FundAggregatorData fundData)
        {
            _fundDataStore.Add(fundData);
        }

        public FundAggregatorData GetFundData(string sedol)
        {
            //TODO: Should use nullable object pattern instead of return null??
            return _fundDataStore.Where(fundData => fundData.Sedol == sedol).SingleOrDefault();
        }
    }
}
