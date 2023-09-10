using Newtonsoft.Json;

namespace StexchangeClient.Models.Response.Markets
{
    public class MarketResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stock")]
        public string Stock { get; set; }

        [JsonProperty("stock_prec")]
        public int StockPrec { get; set; }

        [JsonProperty("money")]
        public string Money { get; set; }

        [JsonProperty("fee_prec")]
        public int FeePrec { get; set; }

        [JsonProperty("min_amount")]
        public string MinAmount { get; set; }

        [JsonProperty("money_prec")]
        public int MoneyPrec { get; set; }
    }
}
