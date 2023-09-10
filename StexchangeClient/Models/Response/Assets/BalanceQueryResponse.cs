using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Assets
{
    public class BalanceQueryResponse
    {
        [JsonProperty("available")]
        public string Available { get; set; }

        [JsonProperty("freeze")]
        public string Freeze { get; set; }
    }
}
