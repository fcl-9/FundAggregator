using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FundAggregator.Worker.CharlesStanley;
using FundAggregator.Worker.HargreavesLansdown.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FundAggregator.Worker.HargreavesLansdown
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDataPullingService _dataPulling;
        private readonly IDataExtractorService _dataExtractionService;

        public Worker(ILogger<Worker> logger, IDataPullingService dataPulling, IDataExtractorService dataExtractionService)
        {
            _logger = logger;
            _dataPulling = dataPulling;
            _dataExtractionService = dataExtractionService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var httpResponse = await _dataPulling.GetFundDataBySedol("B3TYHH9").ConfigureAwait(false);
            var rawData = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            _dataExtractionService.ExtractTopTenGeographies(rawData);
            _dataExtractionService.ExtractTopTenSectors(rawData);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
