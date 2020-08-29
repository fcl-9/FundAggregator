using FundAggregator.Worker.Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Worker.Shared.Interfaces
{
    public interface IFundDataRepository
    {
        void CreateFundData(FundAggregatorData fundData);

        FundAggregatorData GetFundData(string sedol);
    }
}
