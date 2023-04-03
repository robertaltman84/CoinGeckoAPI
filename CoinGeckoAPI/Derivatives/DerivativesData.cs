using Newtonsoft.Json;

namespace CoinGeckoAPI.Derivatives
{
    public class DerivativesData
    {
        public struct DerivativeInfo
        {
            public string Market { get; set; }
            public string Symbol { get; set; }
            public string Index_id { get; set; }
            public string Price { get; set; }

            [JsonProperty("price_percentage_change_24h")]
            public float? PricePercentageChange24h { get; set; }

            [JsonProperty("contract_type")]
            public string? ContractType { get; set; }
            public float? Index { get; set; }
            public float? Basis { get; set; }
            public float? Spread { get; set; }

            [JsonProperty("funding_rate")]
            public float? FundingRate { get; set; }

            [JsonProperty("open_interest")]
            public float? OpenInterest { get; set; }

            [JsonProperty("volume_24h")]
            public float? Volume24h { get; set; }

            [JsonProperty("last_traded_at")]
            public int? LastTradedAt { get; set; }

            [JsonProperty("expired_at")]
            public int? ExpiredAt { get; set; }
        }

        public struct DerivativeExchangeInfo
        {
            public string Name { get; set; }
            public string ID { get; set; }

            [JsonProperty("open_interest_btc")]
            public float? open_interest_btc { get; set; }

            [JsonProperty("trade_volume_24h_btc")]
            public string trade_volume_24h_btc { get; set; }

            [JsonProperty("number_of_perpetual_pairs")]
            public int NumberOfPerpetualPairs { get; set; }

            [JsonProperty("number_of_futures_pairs")]
            public int NumberOfFuturesPairs { get; set; }
            public string Image { get; set; }

            [JsonProperty("year_established")]
            public int? YearEstablished { get; set; }
            public object Country { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
        }

        public struct DerivativeExchangeInfoSimple
        { 
            string ID { get; set; }
            string Name { get; set; }
        }

        public struct DerivativesExchange
        {
            public string Name { get; set; }

            [JsonProperty("open_interest_btc")]
            public float OpenInterestBTC { get; set; }

            [JsonProperty("trade_volume_24h_btc")]
            public string TradeVolume24hBTC { get; set; }

            [JsonProperty("number_of_perpetual_pairs")] 
            public int NumberOfPerpetualPairs { get; set; }

            [JsonProperty("number_of_futures_pairs")] 
            public int NumberOfFuturesPairs { get; set; }
            public string Image { get; set; }

            [JsonProperty("year_established")]
            public object YearEstablished { get; set; }
            public string Country { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
            public Ticker[] Tickers { get; set; }
        }

        public struct Ticker
        {
            public string Symbol { get; set; }

            [JsonProperty("_base")]
            public string Base { get; set; }
            public string Target { get; set; }


            [JsonProperty("trade_url")] 
            public string TradeUrl { get; set; }

            [JsonProperty("contract_type")] 
            public string ContractType { get; set; }
            public float Last { get; set; }

            [JsonProperty("h24_percentage_change")] 
            public float PercentageChange24H { get; set; }
            public float Index { get; set; }

            [JsonProperty("index_basis_percentage")]
            public float IndexBasisPercentage { get; set; }

            [JsonProperty("bid_ask_spread")]             
            public float BidAskSpread { get; set; }

            [JsonProperty("funding_rate")]
            public float FundingRate { get; set; }

            [JsonProperty("open_interest_usd")]
            public float OpenInterestUSD { get; set; }
                        
            [JsonProperty("h24_volume")] 
            public float Volume24h { get; set; }

            [JsonProperty("Converted_Volume")]
            public ConvertedVolume ConvertedVolume { get; set; }

            [JsonProperty("Converted_Last")]
            public ConvertedLast ConvertedLast { get; set; }

            [JsonProperty("last_traded")]
            public int last_traded { get; set; }

            [JsonProperty("expired_at")]
            public int? expired_at { get; set; }
        }

        public struct ConvertedVolume
        {
            public string BTC { get; set; }
            public string ETH { get; set; }
            public string USD { get; set; }
        }

        public struct ConvertedLast
        {
            public string BTC { get; set; }
            public string ETH { get; set; }
            public string USD { get; set; }
        }

    }
}
