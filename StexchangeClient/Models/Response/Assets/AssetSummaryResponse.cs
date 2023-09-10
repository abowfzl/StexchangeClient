using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Assets
{
    public class AssetSummaryResponse
    {
        [JsonProperty("freeze_count")]
        public int FreezeCount { get; set; }

        [JsonProperty("name")]
        public string AssetName { get; set; }

        [JsonProperty("total_balance")]
        public string TotalBalance { get; set; }

        [JsonProperty("available_count")]
        public int AvailableCount { get; set; }

        [JsonProperty("freeze_balance")]
        public string FreezeBalance { get; set; }

        [JsonProperty("available_balance")]
        public string AvailableBalance { get; set; }
    }
}
