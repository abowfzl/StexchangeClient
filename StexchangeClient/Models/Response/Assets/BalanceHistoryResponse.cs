using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Assets
{
    public class BalanceHistoryDetail
    {
        [JsonProperty("time")]
        public decimal Time { get; set; }

        [JsonProperty("asset")]
        public string AssetName { get; set; }

        [JsonProperty("business")]
        public string BusinessType { get; set; }

        [JsonProperty("change")]
        public decimal Change { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}
