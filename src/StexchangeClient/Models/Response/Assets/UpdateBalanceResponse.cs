using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Assets
{
    public class UpdateBalanceResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
