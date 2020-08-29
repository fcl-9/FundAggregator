using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FundAggregator.Worker.HargreavesLansdown.Services
{
    public interface IDataPullingService
    {
        Task<HttpResponseMessage> GetFundDataBySedol(string sedol);
    }
}
