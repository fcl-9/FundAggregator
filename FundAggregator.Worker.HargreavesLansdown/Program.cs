using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FundAggregator.Worker.CharlesStanley;
using FundAggregator.Worker.HargreavesLansdown.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FundAggregator.Worker.HargreavesLansdown
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
                    services.AddSingleton<IDataExtractorService, DataExtractorService>();
                    services.AddHttpClient<IDataPullingService, DataPullingService>();
                    services.AddHostedService<Worker>();
                });
    }
}
