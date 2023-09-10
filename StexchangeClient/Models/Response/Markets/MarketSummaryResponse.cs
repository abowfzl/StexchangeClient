using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Markets
{
    public class MarketSummaryResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("bid_amount")]
        public string BidAmount { get; set; }

        [JsonProperty("bid_count")]
        public int BidCount { get; set; }

        [JsonProperty("ask_count")]
        public int AskCount { get; set; }

        [JsonProperty("ask_amount")]
        public string AskAmount { get; set; }
    }
}
