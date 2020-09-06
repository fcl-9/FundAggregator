using System.Collections.Generic;
using FundAggregator.Worker.Shared.DataTransferObject;
using FundAggregator.Worker.Shared.ExternalModels;

namespace FundAggregator.Data.HargreavesLansdown.Builder
{
    internal class FundAggregatorDataBuilder
    {
        private FundAggregatorData _fundAggregatorData;

        public FundAggregatorDataBuilder()
        {
            _fundAggregatorData = new FundAggregatorData();
        }

        public FundAggregatorDataBuilder WithFundName(string fundName)
        {
            _fundAggregatorData.FundName = fundName;
            return this;
        }
        public FundAggregatorDataBuilder WithFundIssuer(string fundIssuer)
        {
            _fundAggregatorData.Issuer = fundIssuer;
            return this;
        }

        public FundAggregatorDataBuilder WithFundIdentifiers(FundIdentifiers fundIdentifiers)
        {
            _fundAggregatorData.FundIdentifiders = fundIdentifiers;
            return this;
        }

        public FundAggregatorDataBuilder WithTopTenGeography(IList<TopTen> topTenGeography)
        {
            foreach (var country in topTenGeography)
            {
                _fundAggregatorData.TopTenGeography.Add(country.Name, country.Percentage);
            }
            return this;
        }
        public FundAggregatorDataBuilder WithTopTenSectors(IList<TopTen> topTenSectors)
        {
            foreach (var sector in topTenSectors)
            {
                _fundAggregatorData.TopTenSectors.Add(sector.Name, sector.Percentage);
            }
            return this;
        }

        public FundAggregatorData Build()
        {
            return _fundAggregatorData;
        }
    }
}