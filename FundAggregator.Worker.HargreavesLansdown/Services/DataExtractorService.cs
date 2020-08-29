using FundAggregator.Worker.CharlesStanley;
using FundAggregator.Worker.CharlesStanley.ExternalModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace FundAggregator.Worker.HargreavesLansdown
{
    public class DataExtractorService : IDataExtractorService
    {
        const string topTenSectorsInitialRegexPattern = "(var dataCompositionSectors =?)";
        const string topTenSectorsRegexPattern = @"(var dataCompositionSectors =?)(.*?)(])";
        const string topTenGeographyInitialRegexPattern = "(var dataCompositionGeography =?)";
        const string topTenGeographyRegexPattern = @"(var dataCompositionGeography =?)(.*?)(])";
        const string removePercentages = @"\(.*?\)";
        private ILogger<DataExtractorService> _logger;

        public DataExtractorService(ILogger<DataExtractorService> logger) {
            _logger = logger;
        }

        public void ExtractTopTenGeographies(string rawData)
        {
            var regexMatch = Regex.Match(rawData, topTenGeographyRegexPattern);
            if (!regexMatch.Success) {
                _logger.LogError("Could not find the pattern for TopTenGeographies page may have been modified.");
                return;
            }
            var topTenGeography = Regex.Replace(regexMatch.Value, removePercentages, string.Empty);
            topTenGeography = Regex.Replace(topTenGeography, topTenGeographyInitialRegexPattern, string.Empty);

            try
            {
                var topTen = JsonSerializer.Deserialize<IList<TopTen>>(topTenGeography);
            }
            catch (Exception e) {
                _logger.LogError("Could not convert TopTenGeographies data into internal data type.");
            }

        }

        public void ExtractTopTenSectors(string rawData)
        {
            var regexMatch = Regex.Match(rawData, topTenSectorsRegexPattern);
            if (!regexMatch.Success)
            {
                _logger.LogError("Could not find the pattern for TopTenSectors page may have been modified.");
                return;
            }
            var topTenSectors = Regex.Replace(regexMatch.Value, removePercentages, string.Empty);
            topTenSectors = Regex.Replace(topTenSectors, topTenSectorsInitialRegexPattern, string.Empty);
            try
            {
                var topTen = JsonSerializer.Deserialize<IList<TopTen>>(topTenSectors);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not convert TopTenSectors data into internal data type.");
            }
        }
    }
}