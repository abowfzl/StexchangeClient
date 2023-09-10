using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Orders
{
    public class OrderDealDetailResponse
    {
        [JsonProperty("time")]
        public double Time { get; set; }

        [JsonProperty("user")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("deal")]
        public string Deal { get; set; }

        [JsonProperty("role")]
        public int Role { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("deal_order_id")]
        public int DealOrderId { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("order_id")]
        public int OrderId { get; set; }
    }
}
