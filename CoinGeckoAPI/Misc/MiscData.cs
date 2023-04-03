using Newtonsoft.Json;
using static CoinGeckoAPI.Misc.MiscData;

namespace CoinGeckoAPI.Misc
{
    public class MiscData
    {
        public struct ExchangeRate
        {
            public string CoinName;
            public string Unit;
            public float Rate;
            public string Type;
        }
        public struct SearchResult
        {
            public struct Coin
            {
                public string ID { get; set; }
                public string Name { get; set; }

                [JsonProperty("api_symbol")]
                public string APISymbol { get; set; }
                public string Symbol { get; set; }

                [JsonProperty("market_cap_rank")]
                public int? MarketCapRank { get; set; }
                public string Thumb { get; set; }
                public string Large { get; set; }
            }
            public Coin[] Coins { get; set; }
            public Exchange[] Exchanges { get; set; }
            public object[] ICOs { get; set; }
            public Category[] Categories { get; set; }
            public Nft[] NFTs { get; set; }
        }        
        public struct Exchange
        {
            public string ID { get; set; }
            public string Name { get; set; }

            [JsonProperty("market_type")]
            public string MarketType { get; set; }
            public string Thumb { get; set; }
            public string Large { get; set; }
        }
        public struct Category
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public struct Nft
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Symbol { get; set; }
            public string Thumb { get; set; }
        }
        public struct TrendingResults
        {
            [JsonProperty("coins")]
            public List<TrendyCoin> Coins { get; set; }
            public object[] Exchanges { get; set; }
        }
        public struct TrendyCoin
        {
            [JsonProperty("item")]
            Coin Coin { get; set; }
        }
        public struct Coin
        {

            [JsonProperty("id")]
            public string ID { get; set; }

            [JsonProperty("coin_id")]
            public int CoinID { get; set; }
            public string Name { get; set; }
            public string Symbol { get; set; }

            [JsonProperty("market_cap_rank")]
            public int MarketCapRank { get; set; }
            public string Thumb { get; set; }
            public string Small { get; set; }
            public string Large { get; set; }
            public string Slug { get; set; }

            [JsonProperty("price_btc")]
            public float PriceBTC { get; set; }
            public int Score { get; set; }
        }
        public struct CryptoGlobal
        {
            public struct GlobalData
            {
                [JsonProperty("active_cryptocurrencies")]
                string ActiveCurrencies { get; set; }

                [JsonProperty("upcoming_icos")]
                int UpcomingICOs { get; set; }

                [JsonProperty("ended_icos")]
                int EndedICOs { get; set; }

                int Marketes { get; set; }

                [JsonProperty("total_market_cap")]
                Dictionary<string, float> TotalMarketCap { get; set; }

                [JsonProperty("total_volume")]
                Dictionary<string, float> TotalVolume { get; set; }

                [JsonProperty("market_cap_percentage")]
                Dictionary<string, float> MarketCapPercentage { get; set; }

                [JsonProperty("market_cap_change_percentage_24h_usd")]
                float MarketCapChangePercentage24hUSD { get; set; }

                [JsonProperty("updated_at")]
                int UpdatedAt { get; set; }
            }
            public GlobalData Data { get; set; }
        }
    }
}
