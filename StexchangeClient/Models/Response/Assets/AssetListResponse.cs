using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Assets
{
    public class AssetListResponse
    {
        [JsonProperty("name")]
        public string AssetName { get; set; }

        [JsonProperty("prec")]
        public int Prec { get; set; }
    }
}
