using NServiceBus;
using System;
using System.Net;

namespace FundAggregator.Configuration.NServiceBus
{
    public static class NServiceBusConfiguration
    {
        public static EndpointConfiguration ConfigureEndpoint(NServiceBusSettings endPointSettings) {

            var endpointConfiguration = new EndpointConfiguration(endPointSettings.EndpointName);

            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UsePersistence<LearningPersistence>();
            return endpointConfiguration;
        }
    }
}
