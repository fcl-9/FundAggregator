using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FundAggregator.Worker.CharlesStanley.ExternalModels
{
    public class TopTen
    {
        [JsonPropertyName("tooltip")]
        public string Tooltip { get; set; }
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
    }
}
