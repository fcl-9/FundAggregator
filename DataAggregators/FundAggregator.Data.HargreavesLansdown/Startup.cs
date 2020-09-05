using FundAggregator.Data.HargreavesLansdown;
using FundAggregator.Data.HargreavesLansdown.Enum;
using FundAggregator.Data.HargreavesLansdown.Factories;
using FundAggregator.Data.HargreavesLansdown.Services;
using FundAggregator.Worker.Shared.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[assembly: FunctionsStartup(typeof(Startup))]


namespace FundAggregator.Data.HargreavesLansdown
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IWebDriver>(container => WebDriverFactory.Create(DriverType.GoogleChrome));
            builder.Services.AddScoped<IDataExtractorService<IWebDriver>, DataExtractorService>();
            builder.Services.AddScoped<IDataPullingService, DataPullingService>();
        }
    }
}