using FundAggregator.Worker.CharlesStanley.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Worker.CharlesStanley
{
    public interface IDataExtractorService
    {
        string ExtractFundName(string rawData);
        IList<TopTen> ExtractTopTenGeographies(string rawData);

        IList<TopTen> ExtractTopTenSectors(string rawData);
    }
}
