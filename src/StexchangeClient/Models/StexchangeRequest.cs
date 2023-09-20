using Newtonsoft.Json;
using System.Collections.Generic;

namespace StexchangeClient.Models
{
    internal class StexchangeRequest
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public IEnumerable<object> @Params { get; set; } = new List<object>();

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
