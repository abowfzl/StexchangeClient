using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Assets
{
    public class BalanceQueryResponse
    {
        [JsonProperty("available")]
        public string NormalizeAvailable { get; set; }

        [JsonProperty("freeze")]
        public string NormalizeFreeze { get; set; }
    }
}
