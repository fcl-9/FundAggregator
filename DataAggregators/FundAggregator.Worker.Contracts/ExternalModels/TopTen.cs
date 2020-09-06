using System.Text.Json.Serialization;

namespace FundAggregator.Worker.Shared.ExternalModels
{
    public class TopTen
    {
        public string Name { get; set; }
        public decimal Percentage { get; set; }
    }
}
