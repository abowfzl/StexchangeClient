using Newtonsoft.Json;

namespace StexchangeClient.Models
{
    public class ErrorStexchange
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
