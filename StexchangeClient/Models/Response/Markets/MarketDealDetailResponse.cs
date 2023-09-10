using Newtonsoft.Json;
using StexchangeClient.Enums;

namespace StexchangeClient.Models.Response.Markets
{
    public class MarketDealDetailResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("time")]
        public double Time { get; set; }

        [JsonProperty("type")]
        public OrderSide Type { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
