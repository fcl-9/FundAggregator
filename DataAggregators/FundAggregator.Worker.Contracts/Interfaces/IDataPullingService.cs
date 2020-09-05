using System.Net.Http;
using System.Threading.Tasks;

namespace FundAggregator.Worker.Shared.Interfaces
{
    public interface IDataPullingService
    {
        void GetFundData(string fundIdentifier);
    }
}
