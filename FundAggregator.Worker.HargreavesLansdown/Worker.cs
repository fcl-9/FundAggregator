using System;
using System.Threading;
using System.Threading.Tasks;
using FundAggregator.Worker.CharlesStanley;
using FundAggregator.Worker.CharlesStanley.Builder;
using FundAggregator.Worker.HargreavesLansdown.Services;
using FundAggregator.Worker.Shared.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FundAggregator.Worker.CharlesStanley
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDataPullingService _dataPulling;
        private readonly IDataExtractorService _dataExtractionService;
        private readonly IFundDataRepository _fundDataRepo;

        public Worker(ILogger<Worker> logger, IDataPullingService dataPulling, IDataExtractorService dataExtractionService, IFundDataRepository fundDataRepo)
        {
            _logger = logger;
            _dataPulling = dataPulling;
            _dataExtractionService = dataExtractionService;
            _fundDataRepo = fundDataRepo;
        }

        //TODO: This can be most probably turned into an azure functions that is using a 
        //time trigger and publishes a message to a queue with the raw data that was retrieved.
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var httpResponse = await _dataPulling.GetFundDataBySedol("B3TYHH9").ConfigureAwait(false);
                var rawData = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var fundName = _dataExtractionService.ExtractFundName(rawData);
                var topTenGeography = _dataExtractionService.ExtractTopTenGeographies(rawData);
                var topTenSectors = _dataExtractionService.ExtractTopTenSectors(rawData);

                var fundData = new FundAggregatorDataBuilder()
                    .WithFundName(fundName)
                    .WithFundIdentifiers(string.Empty, string.Empty, string.Empty)
                    .WithTopTenGeography(topTenGeography)
                    .WithTopTenSectors(topTenSectors)
                    .Build();

                _fundDataRepo.CreateFundData(fundData);

                // Run Each 24 Hours
                await Task.Delay(86400000, stoppingToken);
            }
        }
    }
}
