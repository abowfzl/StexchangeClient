using Newtonsoft.Json;
using StexchangeClient.Enums;

namespace StexchangeClient.Models.Response.Orders
{
    public class OrderDetailResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("side")]
        public OrderSide Side { get; set; }

        [JsonProperty("type")]
        public OrderType Type { get; set; }

        [JsonProperty("deal_money")]
        public string DealMoney { get; set; }

        [JsonProperty("ctime")]
        public double Ctime { get; set; }

        [JsonProperty("ftime")]
        public double Ftime { get; set; }

        [JsonProperty("user")]
        public int UserId { get; set; }

        [JsonProperty("market")]
        public string MarketName { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("taker_fee")]
        public string TakerFee { get; set; }

        [JsonProperty("maker_fee")]
        public string MakerFee { get; set; }

        [JsonProperty("deal_stock")]
        public string DealStock { get; set; }

        [JsonProperty("deal_fee")]
        public string DealFee { get; set; }

        [JsonProperty("left")]
        public string Left { get; set; }

        [JsonProperty("mtime")]
        public double Mtime { get; set; }
    }
}
