using FundAggregator.Worker.CharlesStanley.Services;
using FundAggregator.Worker.HargreavesLansdown.Services;
using FundAggregator.Worker.Shared.Infrastructure;
using FundAggregator.Worker.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FundAggregator.Worker.CharlesStanley
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IFundDataRepository, FundDataRepository>();
                    services.AddSingleton<IDataExtractorService, DataExtractorService>();
                    services.AddHttpClient<IDataPullingService, DataPullingService>();
                    services.AddHostedService<Worker>();
                });
    }
}
