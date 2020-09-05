using System.Collections.Generic;
using FundAggregator.Worker.Shared.ExternalModels;

namespace FundAggregator.Worker.Shared.Interfaces
{
    public interface IDataExtractorService<T>
    {
        string ExtractFundName(T rawData);
        IList<TopTen> ExtractTopTenGeographies(T rawData);

        IList<TopTen> ExtractTopTenSectors(T rawData);
    }
}
