using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Worker.CharlesStanley
{
    public interface IDataExtractorService
    {
        void ExtractTopTenGeographies(string rawData);

        void ExtractTopTenSectors(string rawData);
    }
}
