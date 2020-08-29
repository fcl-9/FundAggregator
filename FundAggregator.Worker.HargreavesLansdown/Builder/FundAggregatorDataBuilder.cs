using FundAggregator.Worker.CharlesStanley.ExternalModels;
using FundAggregator.Worker.Shared.DataTransferObject;
using System;
using System.Collections.Generic;

namespace FundAggregator.Worker.CharlesStanley.Builder
{
    internal class FundAggregatorDataBuilder
    {
        private FundAggregatorData _fundAggregatorData;
        
        public FundAggregatorDataBuilder()
        {
            _fundAggregatorData = new FundAggregatorData();
        }

        public FundAggregatorDataBuilder WithFundName(string fundName) {
            _fundAggregatorData.FundName = fundName;
            return this;
        }
        public FundAggregatorDataBuilder WithFundIdentifiers(string sedol, string isin, string apir) {
            _fundAggregatorData.Apir = apir;
            _fundAggregatorData.Isin = isin;
            _fundAggregatorData.Sedol = sedol;
            return this;
        }

        public FundAggregatorDataBuilder WithTopTenGeography(IList<TopTen> topTenGeography) {
            foreach (var country in topTenGeography) {
                _fundAggregatorData.TopTenGeography.Add(country.Tooltip, decimal.Parse(country.Amount));
            }
            return this;
        }
        public FundAggregatorDataBuilder WithTopTenSectors(IList<TopTen> topTenSectors) {
            foreach (var sector in topTenSectors)
            {
                _fundAggregatorData.TopTenSectors.Add(sector.Tooltip, decimal.Parse(sector.Amount));
            }
            return this;
        }

        public FundAggregatorData Build() {
            return _fundAggregatorData;
        }
    }
}
