using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FundAggregator.Data.HargreavesLansdown.Builder;
using FundAggregator.Data.HargreavesLansdown.Services;
using FundAggregator.Worker.Shared.DataTransferObject;
using FundAggregator.Worker.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FundAggregator.Data.HargreavesLansdown
{
    public class FundFunction
    {
        private IDataPullingService _pullingService;

        public FundFunction(IDataPullingService pullingService)
        {
            _pullingService = pullingService;
        }

        [FunctionName("Fund")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(databaseName: "MutualFunds", collectionName: "Funds", ConnectionStringSetting = "CosmosDBConnection")] IAsyncCollector<FundAggregatorData> fundDataOut,

            ILogger log)
        {
            var fundIdentifier = "IE00B8GKDB10";
            var fundData = _pullingService.GetFundData(fundIdentifier);
            await fundDataOut.AddAsync(fundData, CancellationToken.None);
            return new OkObjectResult(fundData);
        }


    }
}
