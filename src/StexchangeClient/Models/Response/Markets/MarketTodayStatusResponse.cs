using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Markets
{
    public class MarketTodayStatusResponse
    {
        [JsonProperty("open")]
        public string Open { get; set; }

        [JsonProperty("deal")]
        public string Deal { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }
    }
}
