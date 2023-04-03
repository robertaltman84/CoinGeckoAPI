using Newtonsoft.Json;

namespace CoinGeckoAPI.Exchanges
{
    public class ExchangeData
    {
        public struct ExchangeTickerList
        {
            public string Name { get; set; }
            public List<Ticker> Tickers { get; set; }
        }

        public struct Exchange
        {
            public string ID { get; set; }
            public string Name { get; set; }

            [JsonProperty("year_established")]
            public int Year { get; set; }
            public string Country { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
            public string Image { get; set; }

            [JsonProperty("has_trading_incentives")]
            public bool HasTradingIncentives { get; set; }

            [JsonProperty("trust_score")]
            public int TrustScore { get; set; }

            [JsonProperty("trust_score_rank")]
            public int TrustScoreRank { get; set; }

            [JsonProperty("trade_vol_24h_btc")]
            public float TradeVolumne24hBitCoin { get; set; }

            [JsonProperty("trade_vol_24h_btc_normalized")]
            public float TradeVolumne24hBitCoinNormalized { get; set; }
        }


        public struct ExchangeVolumeChart
        {
            public float TimeStamp { get; set; }
            public string Volume { get; set; }            
        }

        public struct ExchangeInfo
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }

        public struct ExchangeInfoFull
        {
            public string Name { get; set; }

            [JsonProperty("year_established")]
            public object YearEstablished { get; set; }
            public object Country { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
            public string Image { get; set; }
            public string Facebook_url { get; set; }
            public string Reddit_url { get; set; }
            public string Telegram_url { get; set; }
            public string Slack_url { get; set; }

            [JsonProperty("other_url_1")]
            public string OtherUrl1 { get; set; }

            [JsonProperty("other_url_2")]
            public string OtherUrl2 { get; set; }

            [JsonProperty("twitter_handle")]
            public string TwitterHandle { get; set; }

            [JsonProperty("has_trading_incentive")]
            public bool HasTradingIncentive { get; set; }
            public bool Centralized { get; set; }

            [JsonProperty("public_notice")]
            public string PublicNotice { get; set; }

            [JsonProperty("alert_notice")]
            public string AlertNotice { get; set; }

            [JsonProperty("trust_score")]
            public int? TrustScore { get; set; }

            [JsonProperty("trade_volume_24h_btc")]
            public float TradeVolume24hBtc { get; set; }

            [JsonProperty("trade_volume_24h_btc_normalized")]
            public float TradeVolume24hBtcNormalized { get; set; }
            public Ticker[] Tickers { get; set; }

            [JsonProperty("status_updates")]
            public object[] StatusUpdates { get; set; }

        }

        public struct Ticker
        {
            [JsonProperty("_base")]
            public string Base { get; set; }
            public string Target { get; set; }
            public Market Market { get; set; }
            public float Last { get; set; }
            public float Volume { get; set; }

            [JsonProperty("converted_last")]
            public ConvertedLast ConvertedLast { get; set; }

            [JsonProperty("converted_volume")]
            public ConvertedVolume ConvertedVolume { get; set; }

            [JsonProperty("trust_score")]
            public string TrustScore { get; set; }

            [JsonProperty("bid_ask_spread_percentage")]
            public float BidAskSpreadPercentage { get; set; }
            public DateTime Timestamp { get; set; }

            [JsonProperty("last_traded_at")]
            public DateTime LastTradedAt { get; set; }

            [JsonProperty("last_fetch_at")]
            public DateTime LastFetchAt { get; set; }

            [JsonProperty("is_anomaly")]
            public bool IsAnomaly { get; set; }

            [JsonProperty("is_stale")]
            public bool IsStale { get; set; }

            [JsonProperty("trade_url")]
            public string TradeURL { get; set; }

            [JsonProperty("token_info_url")]
            public object TokenInfoURL { get; set; }

            [JsonProperty("coin_id")]
            public string CoinID { get; set; }

            [JsonProperty("target_coin_id")]
            public string TargetCoinID { get; set; }

        }

        public struct Market
        {
            internal string Name { get; set; }
            internal string Identifier { get; set; }
            [JsonProperty("has_trading_incentive")]
            internal bool HasTradingIncentive { get; set; }
        }

        public struct ConvertedLast
        {
            internal float BTC { get; set; }
            internal float ETH { get; set; }
            internal float USD { get; set; }
        }

        public struct ConvertedVolume
        {
            internal float BTC { get; set; }
            internal float ETH { get; set; }
            internal float USD { get; set; }
        }
    }
}
