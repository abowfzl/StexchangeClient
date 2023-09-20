using Newtonsoft.Json;
using System.Collections.Generic;

namespace StexchangeClient.Models.Response.Orders
{
    public class OrderBookResponse
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("orders")]
        public IList<OrderDetailResponse> Orders { get; set; }
    }
}
