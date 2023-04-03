using Newtonsoft.Json;

namespace CoinGeckoAPI.Coin
{
    public class CoinData
    {
        public struct Coin
        {
            public Info Info { get; set; }
            public OpenHighLowClose OpenHighLowClose { get; set; }
            public ChartPriceData ChartPriceData { get; set; }
            public HistoricalData HistoricalData { get; set; }
            public Tickers Tickers { get; set; }
        }


        #region Coin Info

        public struct Info
        {
            public static string ID { get; set; }
            public string Symbol { get; set; }
            public string Name { get; set; }
        }
        public struct OpenHighLowClose
        {
            internal OpenHighLowCloseData[] Data { get; set; }
        }
        internal struct OpenHighLowCloseData
        {
            internal decimal Open { get; set; }
            internal decimal Close { get; set; }
            internal decimal High { get; set; }
            internal decimal Low { get; set; }
        }
        public struct ChartPriceData
        {
            [JsonProperty("prices")]
            decimal[][] Prices { get; set; }
        }
        public struct HistoricalData
        {
            internal string ID { get; set; }
            internal string Symbol { get; set; }
            internal string Name { get; set; }

            [JsonProperty("image")]
            internal CoinImage CoinImage { get; set; }

            [JsonProperty("market_data")]
            internal MarketData MarketData { get; set; }

            [JsonProperty("market_cap")]
            internal MarketCap MarketCap { get; set; }

            [JsonProperty("total_volume")]
            internal TotalVolume TotalVolume { get; set; }

            [JsonProperty("community_data")]
            internal CommunityData CommunityData { get; set; }

            [JsonProperty("developer_data")]
            internal DeveloperData DeveloperData { get; set; }

            [JsonProperty("internal_interest_stats")]
            internal internalInterestStats internalInterestStats { get; set; }
        }
        internal struct internalInterestStats
        {
            [JsonProperty("alexa_rank")]

            internal string AlexaRank { get; set; }

            [JsonProperty("bing_matches")]

            internal string BingMatches { get; set; }
        }
        internal struct DeveloperData
        {
            [JsonProperty("forks")]

            internal string Forks { get; set; }

            [JsonProperty("stars")]

            internal string Stars { get; set; }

            [JsonProperty("subscribers")]

            internal string Subscribers { get; set; }

            [JsonProperty("total_issues")]

            internal string TotalIssues { get; set; }

            [JsonProperty("closed_issues")]

            internal string ClosedIssues { get; set; }

            [JsonProperty("pulled_requests_merged")]

            internal string PulledRequestsMerged { get; set; }

            [JsonProperty("pulled_requests_contributers")]

            internal string PulledRequestsContributers { get; set; }

            [JsonProperty("code_additions_deletions_4_weeks")]

            internal CodeAdditionsDeletions4Weeks CodeAdditionsDeletions4Weeks { get; set; }

            [JsonProperty("commit_count_4_weeks")]
            internal string CommitCount4Weeks { get; set; }
        }
        internal struct CommunityData
        {
            [JsonProperty("facebook_likes")]

            internal string FaceBookLikes { get; set; }

            [JsonProperty("twitter_followers")]

            internal string TwitterFollowers { get; set; }

            [JsonProperty("reddit_average_posts_48h")]

            internal string RedditAveragePosts48H { get; set; }

            [JsonProperty("reddit_average_comments_48h")]

            internal string RedditAverageComments48H { get; set; }

            [JsonProperty("reddit_subscribers")]

            internal string RedditSubscribers { get; set; }

            [JsonProperty("reddit_accounts_active_48h")]

            internal string RedditAccountsActive48H { get; set; }
        }
        internal struct CoinImage
        {
            internal string Thumb { get; set; }
            internal string Small { get; set; }
        }
        public struct Tickers
        {
            internal string Base { get; set; }

            internal string Target { get; set; }

            [JsonProperty("market")]

            internal Market Market { get; set; }

            internal string Last { get; set; }

            internal string Volume { get; set; }

            [JsonProperty("converted_last")]

            internal ConvertedLast ConvertedLast { get; set; }

            [JsonProperty("converted_volume")]

            internal ConvertedLast ConvertedVolume { get; set; }

            [JsonProperty("trust_score")]
            internal string TrustScore { get; set; }

            [JsonProperty("bid_ask_spread_percentage")]
            internal string BidAskSpreadPercentage { get; set; }

            [JsonProperty("timestamp")]
            internal string TimeStamp { get; set; }

            [JsonProperty("last_traded_at")]
            internal string LastTradedAt { get; set; }

            [JsonProperty("last_fetch_at")]
            internal string LastFetchAt { get; set; }

            [JsonProperty("is_anomaly")]
            internal string IsAnomaly { get; set; }

            [JsonProperty("is_stale")]
            internal string IsStale { get; set; }

            [JsonProperty("trade_url")]
            internal string TradeURL { get; set; }

            [JsonProperty("token_url")]
            internal string TokenInfoURL { get; set; }

            [JsonProperty("coin_id")]
            internal string CoinID { get; set; }

            [JsonProperty("target_coin_id")]
            internal string TargetCoinID { get; set; }

        }
        internal struct MarketData
        {
            [JsonProperty("current_price")]
            internal CurrentPrice CurrentPrice { get; set; }

            [JsonProperty("total_Volume")]
            internal TotalVolume TotalVolume { get; set; }

            [JsonProperty("market_cap")]
            internal MarketCap MarketCap { get; set; }

            [JsonProperty("ath")]
            internal AllTimeHigh AllTimeHigh { get; set; }

            [JsonProperty("atl")]
            internal AllTimeHigh AllTimeLow { get; set; }

            [JsonProperty("high_24h")]
            internal High24H High24H { get; set; }

            [JsonProperty("low_24h")]
            internal Low24H Low24H { get; set; }
        }
        internal struct CodeAdditionsDeletions4Weeks
        {
            internal string Additions { get; set; }
            internal string Deletions { get; set; }
        }
        internal struct CurrentPrice
        {
            [JsonProperty("usd")]
            internal decimal Price { get; set; }
        }
        internal struct AllTimeHigh
        {
            [JsonProperty("usd")]
            internal decimal Usd { get; set; }
        }
        internal struct AllTimeLow
        {
            [JsonProperty("usd")]
            internal decimal Usd { get; set; }
        }
        internal struct MarketCap
        {
            [JsonProperty("usd")]
            internal decimal Usd { get; set; }
        }
        internal struct TotalVolume
        {
            [JsonProperty("usd")]
            internal decimal Usd { get; set; }
        }
        internal struct High24H
        {
            [JsonProperty("high_24h")]
            internal decimal Usd { get; set; }
        }
        internal struct Low24H
        {
            [JsonProperty("low_24h")]
            internal decimal Usd { get; set; }
        }
        internal struct Market
        {
            [JsonProperty("name")]
            internal string Name { get; set; }
            [JsonProperty("identifier")]
            internal string Identifier { get; set; }
            [JsonProperty("has_trading_incentive")]
            internal string HasTradingIncentive { get; set; }
        }
        internal struct ConvertedLast
        {
            [JsonProperty("btc")]
            internal string BTC { get; set; }
            [JsonProperty("eth")]
            internal string ETH { get; set; }
            [JsonProperty("usd")]
            internal string USD { get; set; }
        }
        internal struct ConvertedVolume
        {
            [JsonProperty("btc")]
            internal string BTC { get; set; }
            [JsonProperty("eth")]
            internal string ETH { get; set; }
            [JsonProperty("usd")]
            internal string USD { get; set; }
        }
        #endregion
    }
}
