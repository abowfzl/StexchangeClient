using Newtonsoft.Json;
using System.Collections.Generic;

namespace StexchangeClient.Models.Response.Orders
{
    public class OrderDepthResponse
    {
        [JsonProperty("asks")]
        public IList<List<string>> Asks { get; set; }

        [JsonProperty("bids")]
        public IList<List<string>> Bids { get; set; }
    }
}
