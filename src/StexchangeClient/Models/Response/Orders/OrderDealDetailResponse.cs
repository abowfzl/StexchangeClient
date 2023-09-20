using Newtonsoft.Json;
using StexchangeClient.Enums;

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
        public UserRole Role { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("deal_order_id")]
        public int DealOrderId { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("side")]
        public OrderSide Side { get; set; }
    }
}
