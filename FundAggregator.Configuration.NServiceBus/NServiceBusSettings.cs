using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Configuration.NServiceBus
{
    public class NServiceBusSettings
    {
        public string EndpointName { get; set; }
        public string PersistenceConnectionString { get; set; }
    }
}
