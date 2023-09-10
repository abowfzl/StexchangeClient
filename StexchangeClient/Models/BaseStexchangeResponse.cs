using Newtonsoft.Json;

namespace StexchangeClient.Models
{
    public class BaseStexchangeResponse<T> where T : class
    {
        [JsonProperty("error")]
        public ErrorStexchange Error { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
