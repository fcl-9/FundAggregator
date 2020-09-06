using System.Net.Http;
using System.Threading.Tasks;
using FundAggregator.Worker.Shared.DataTransferObject;

namespace FundAggregator.Worker.Shared.Interfaces
{
    public interface IDataPullingService
    {
        FundAggregatorData GetFundData(string fundIdentifier);
    }
}
