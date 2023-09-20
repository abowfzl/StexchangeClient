using Newtonsoft.Json;
using System.Collections.Generic;

namespace StexchangeClient.Models
{
    public class PagedStexchangeResponse<T> where T : class
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("records")]
        public IList<T> Records { get; set; }
    }
}
