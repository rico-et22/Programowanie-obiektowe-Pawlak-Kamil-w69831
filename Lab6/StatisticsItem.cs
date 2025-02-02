namespace Lab6
{

    using System.Text.Json.Serialization;

    public class Indicator
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class StatisticsItem
    {
        [JsonPropertyName("indicator")]
        public Indicator Indicator { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("decimal")]
        public string DecimalValue { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}