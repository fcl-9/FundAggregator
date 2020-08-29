using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FundAggregator.Worker.HargreavesLansdown.Services
{
    class DataPullingService: IDataPullingService
    {
        const string charlesStanley = "https://www.charles-stanley-direct.co.uk/ViewFund?Sedol=";
        private HttpClient _httpClient;

        public DataPullingService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> GetFundDataBySedol(string sedol) {
            return _httpClient.GetAsync($"{charlesStanley}{sedol}");
        }
    }
}
