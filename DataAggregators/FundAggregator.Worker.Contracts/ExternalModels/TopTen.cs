using System.Text.Json.Serialization;

namespace FundAggregator.Worker.Shared.ExternalModels
{
    public class TopTen
    {
        public string Name { get; set; }
        public string Percentage { get; set; }
    }
}
