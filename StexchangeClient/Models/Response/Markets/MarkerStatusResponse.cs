using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Markets
{
    public class MarkerStatusResponse
    {
        [JsonProperty("period")]
        public int Period { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("open")]
        public string Open { get; set; }

        [JsonProperty("close")]
        public string Close { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }
    }
}
