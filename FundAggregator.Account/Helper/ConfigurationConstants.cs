using System;
using System.Collections.Generic;
using System.Text;

namespace FundAggregator.Portfolio.Service.Helper
{
    internal static class ConfigurationConstants
    {
        public static string ServiceName = "NServiceBus:ServiceName";
        public static string PersistenceConnectionString = "NServiceBus:PersistenceConnectionString";
        public static string HistoryConnectionString = "ConnectionString:History";
    }
}
