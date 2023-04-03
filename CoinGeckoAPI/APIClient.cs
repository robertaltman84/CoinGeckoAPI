namespace CoinGeckoAPI
{
    using CoinGeckoAPI.AssetPlatforms;
    using CoinGeckoAPI.Coin;
    using CoinGeckoAPI.Derivatives;
    using CoinGeckoAPI.Exchanges;
    using CoinGeckoAPI.Indexes;
    using CoinGeckoAPI.Misc;
    using CoinGeckoAPI.Simple;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    

    public class CoinGeckoAPIClient 
    {
        #region Variables & Declearations

        private HttpClient httpClient = new HttpClient();

        #endregion

        #region Public Classes & Methods
        public class CoinMethods
        {
            private CoinTasks CoinTasks = new CoinTasks();
            private SimpleTasks SimpleTasks = new SimpleTasks();
            public List<CoinData> GetCoinList(bool IncludePlatform = false)
            {
                List<CoinData> coinList = new List<CoinData>();

                var returnData = CoinTasks.GetCoinList(IncludePlatform);

                coinList = returnData.Result;

                return coinList;
            }

            public List<CoinData> GetCoinMarkets(string Currency, string IDs = "", string Category = "",
                string Order = "", int PerPage = 250, int PageNumber = 1, bool Sparkline = false, string PriceChangePercentage = "")
            {
                List<CoinData> coinList = new List<CoinData>();

                var returnData = CoinTasks.GetCoinsMarkets(Currency, IDs, Category, Order, PerPage, PageNumber, Sparkline, PriceChangePercentage);

                coinList = returnData.Result;

                return coinList;
            }

            public CoinData.Info GetCoinInformation(string ID, bool Localization = true, bool IncludeTickerData = true,
                bool IncludeMarketData = true, bool IncludeCommunityData = true, bool IncludeDeveloperData = true, bool Sparkline = false)
            {
                CoinData.Info coinInfo = new CoinData.Info();

                var returnData = CoinTasks.GetCoinInformation(ID, Localization, IncludeTickerData, IncludeMarketData, IncludeCommunityData, IncludeDeveloperData, Sparkline);

                coinInfo = returnData.Result;

                return coinInfo;
            }

            public List<CoinData.Tickers> GetCoinTickers(string ID, string ExchangeIDs = "", bool IncludeExchangeLogo = false,
            int PageNumber = 1, string Order = "", bool Depth = false)
            { 
                List<CoinData.Tickers> tickers = new List<CoinData.Tickers>();

                var responseData = CoinTasks.GetCoinTickers(ID, ExchangeIDs, IncludeExchangeLogo, PageNumber, Order, Depth);

                tickers = responseData.Result;

                return tickers;
            }

            public CoinData.HistoricalData GetHistoricalData(string ID, string Date, bool Localization = false)
            { 
                CoinData.HistoricalData historicalData = new CoinData.HistoricalData();

                var responseData = CoinTasks.GetCoinHistoricalData(ID, Date, Localization);

                historicalData = responseData.Result; 
                
                return historicalData;
            }

            public CoinData.ChartPriceData GetCoinMarketChartData(string ID, string Currency, int Days, string Interval)
            { 
                CoinData.ChartPriceData chartPriceData = new CoinData.ChartPriceData(); 

                var responseData = CoinTasks.GetCoinMarketChartData(ID, Currency, Days, Interval);

                chartPriceData = responseData.Result; 

                return chartPriceData;
            }

            public CoinData.ChartPriceData GetCoinMarketChartDataRange(string ID, string Currency, string FromDate, string ToDate)
            {
                CoinData.ChartPriceData chartPriceData = new CoinData.ChartPriceData();

                var responseData = CoinTasks.GetCoinMarketChartDataRange(ID,  Currency, FromDate, ToDate);

                chartPriceData = responseData.Result;

                return chartPriceData;
            }

            public CoinData.OpenHighLowClose GetCoinOpenHighLowClose(string ID, string Currency, string Days)
            {
                CoinData.OpenHighLowClose openHighLowClose = new CoinData.OpenHighLowClose();

                var responseData = CoinTasks.GetCoinOHLC(ID, Currency, Days);

                openHighLowClose = responseData.Result;

                return openHighLowClose;
            }


        }

        public class SimpleMethods
        {
            private SimpleTasks simpleTasks = new SimpleTasks();
            public List<SimpleData.SimplePrice> GetCoinSimplePrice(string IDs, string Currencies, int Precision, bool IncludeMarketCap = false, bool Include24hrVol = false, 
                                                                        bool Include24hrChange = false, bool IncludeLastUpdatedAt = false)
            {
                List<SimpleData.SimplePrice> simplePrice = new List<SimpleData.SimplePrice>();

                var responseData = simpleTasks.GetPrice(IDs, Currencies, Precision, IncludeMarketCap, Include24hrVol, Include24hrChange, IncludeLastUpdatedAt);

                simplePrice = responseData.Result;

                return simplePrice;
            }

            public SimpleData.SupportedVsCurrencies GetSupportedVsCurrencies()
            {
                SimpleData.SupportedVsCurrencies supportedVsCurrencies = new SimpleData.SupportedVsCurrencies();

                var responseData = simpleTasks.GetSupportedVsCurrencies();

                supportedVsCurrencies.Currencies = responseData.Result;

                return supportedVsCurrencies;
            }
        }

        public class AssetPlatFormMethods
        {
            private AssetPlatformTasks AssetPlatFromTasks = new AssetPlatformTasks();

            /// <summary>
            /// List all asset platforms (Blockchain networks)
            /// </summary>
            /// <param name="filter"></param>
            /// <returns></returns>           
            public AssetPlatformsData GetAssetPlatforms(string Filter = "")
            { 
                AssetPlatformsData assetPlatforms = new AssetPlatformsData();

                var responseData = AssetPlatFromTasks.GetAssetPlatforms(Filter);

                assetPlatforms = responseData.Result;

                return assetPlatforms;
            }

        }

        public class ExchangeMethods
        { 
            private ExchangeTasks ExchangeTasks = new ExchangeTasks();

            /// <summary>
            /// List all exchanges (Active with trading volumes)
            /// </summary>
            /// <param name="perpage"></param>
            /// <param name="page"></param>
            /// <returns></returns>
            public List<ExchangeData.Exchange> GetExchanges(int PerPage, int PageNumber)
            {                
                List<ExchangeData.Exchange> exchangeList =  new List<ExchangeData.Exchange>();

                var responseData = ExchangeTasks.GetExchanges(PerPage, PageNumber);

                exchangeList = responseData.Result;

                return exchangeList;
            }
            /// <summary>
            /// List all supported makrets id and name (no pagination required)
            /// </summary>
            /// <returns></returns>
            public List<ExchangeData.ExchangeInfo> GetExchangesList()
            {
                List<ExchangeData.ExchangeInfo> exchangeList = new List<ExchangeData.ExchangeInfo>();

                var responseData = ExchangeTasks.GetExchangesList();

                exchangeList = responseData.Result;

                return exchangeList;
            }

            /// <summary>
            /// Get the exchange volume in BTC and top 100 tickers ONLY
            /// IMPORTANT
            /// Ticker object is limited to 100 items, to get more tickers, use /exchanges/{id}/tickers
            /// Ticker is_stale is true when ticker that has not been updated/unchanged from the exchange for a while.
            /// Ticker is_anomaly is true if ticker's price is outliered by our system.
            /// You are responsible for managing how you want to display these information(e.g.footnote, different background, change opacity, hide)
            /// </summary>
            /// <param name="ExchangeID"></param>
            /// <returns></returns>
            public ExchangeData.ExchangeInfoFull GetExchangeInfoFull(string ExchangeID)
            { 
                ExchangeData.ExchangeInfoFull infoFull = new ExchangeData.ExchangeInfoFull();

                var responseData = ExchangeTasks.GetExchangeInfoFull(ExchangeID);

                infoFull = responseData.Result;

                return infoFull;
            }

            /// <summary>
            /// Get exchange tickers (paginated, 100 tickers per page)
            /// IMPORTANT:
            /// Ticker is_stale is true when ticker that has not been updated/unchanged from the exchange for a while.
            /// Ticker is_anomaly is true if ticker's price is outliered by our system.
            /// You are responsible for managing how you want to display these information(e.g.footnote, different background, change opacity, hide)
            /// </summary>
            /// <param name="ExchangeID"></param>
            /// <param name="CoinIDs"></param>
            /// <param name="IncludeExchangeLogo"></param>
            /// <param name="Page"></param>
            /// <param name="ShowDepth"></param>
            /// <param name="Order"></param>
            /// <returns></returns>
            public ExchangeData.ExchangeTickerList GetExchangeTickers(string ExchangeID, int Page = 1, string CoinIDs = "", bool IncludeExchangeLogo = false, bool ShowDepth = false, string Order = "trust_score_desc")
            {
                ExchangeData.ExchangeTickerList exchangeTickerList = new ExchangeData.ExchangeTickerList();

                var responseData = ExchangeTasks.GetExchangeTickers(ExchangeID, Page, CoinIDs, IncludeExchangeLogo, ShowDepth, Order);

                exchangeTickerList = responseData.Result;

                return exchangeTickerList;
            }

            /// <summary>
            /// Get volume_chart data (in BTC) for a given exchange
            /// </summary>
            /// <param name="ExchangeID"></param>
            /// <param name="Days"></param>
            /// <returns></returns>
            public List<ExchangeData.ExchangeVolumeChart> GetExchangeVolumeChart(string ExchangeID, int Days)
            {
                List<ExchangeData.ExchangeVolumeChart> finalList = new List<ExchangeData.ExchangeVolumeChart>();

                var responseData = ExchangeTasks.GetExchangeVolumeChartData(ExchangeID, Days);                

                finalList = responseData.Result;

                return finalList;
            }

            /// <summary>
            /// Get volume_chart data (in BTC) for a given exchange by date range
            /// </summary>
            /// <param name="ExchangeID"></param>
            /// <param name="FromDate"></param>
            /// <param name="ToDate"></param>
            /// <returns></returns>
            public List<ExchangeData.ExchangeVolumeChart> GetExchangeVolumeChartRange(string ExchangeID, string FromDate, string ToDate)
            {
                List<ExchangeData.ExchangeVolumeChart> finalList = new List<ExchangeData.ExchangeVolumeChart>();

                var responseData = ExchangeTasks.GetExchangeVolumeChartDataRange(ExchangeID, FromDate, ToDate);

                foreach (ExchangeData.ExchangeVolumeChart volumeChart in responseData.Result)
                {
                    ExchangeData.ExchangeVolumeChart chart = new ExchangeData.ExchangeVolumeChart();

                    chart.TimeStamp = float.Parse(DateTime.UnixEpoch.AddSeconds(Convert.ToDouble(volumeChart.TimeStamp)).ToString());
                    chart.Volume = volumeChart.Volume.ToString();

                    finalList.Add(chart);
                }

                return finalList;
            }
        }

        public class IndexMethods
        {
            private IndexesTasks indexesTasks = new IndexesTasks();

            /// <summary>
            /// List all market indexes
            /// </summary>
            /// <param name="PerPage"></param>
            /// <param name="PageNumber"></param>
            /// <returns></returns>
            public List<IndexesData.IndexInfo> GetIndexesByPage(int PerPage, int PageNumber)
            {
                List<IndexesData.IndexInfo> indexesList = new List<IndexesData.IndexInfo>();

                var responseData = indexesTasks.GetIndexesByPage(PerPage, PageNumber);

                indexesList = responseData.Result;

                return indexesList;
            }

            /// <summary>
            /// List market indexes id and name
            /// </summary>
            /// <param name="PerPage"></param>
            /// <param name="PageNumber"></param>
            /// <returns></returns>
            public List<IndexesData.IndexInfoSimple> GetIndexesList()
            {
                List<IndexesData.IndexInfoSimple> indexesList = new List<IndexesData.IndexInfoSimple>();

                var responseData = indexesTasks.GetIndexesList();

                indexesList = responseData.Result;

                return indexesList;
            }

        }

        public class DerivativeMethods
        { 
            private DerivativesTasks derivativesTasks = new DerivativesTasks();

            /// <summary>
            /// List all derivative tickers
            /// </summary>
            /// <param name="IncludeTickers"></param>
            /// <returns></returns>
            public List<DerivativesData.DerivativeInfo> GetDerivatives(string IncludeTickers = "false")
            { 
                List<DerivativesData.DerivativeInfo>  derivativeInfos = new List<DerivativesData.DerivativeInfo>();

                derivativeInfos = derivativesTasks.GetAllDerivatives(IncludeTickers).Result;

                return derivativeInfos;
            
            }

            /// <summary>
            /// List all derivative exchanges
            /// </summary>
            /// <param name="Order"></param>
            /// <param name="PerPage"></param>
            /// <param name="Page"></param>
            /// <returns></returns>
            public List<DerivativesData.DerivativeExchangeInfo> GetDerivativesExchanges(string Order = "name_asc", int PerPage = 100, int Page = 1)
            {
                List<DerivativesData.DerivativeExchangeInfo> DerivativeExchangeInfos = new List<DerivativesData.DerivativeExchangeInfo>();

                DerivativeExchangeInfos = derivativesTasks.GetDerivativeExchangeInfos(Order, PerPage, Page).Result;

                return DerivativeExchangeInfos;

            }

            /// <summary>
            /// Show derivative exchange data by exchange ID
            /// </summary>
            /// <param name="ExchangeID"></param>
            /// <param name="IncludeTickers"></param>
            /// <returns></returns>
            public DerivativesData.DerivativesExchange GetDerivativeExchangeInfos(string ExchangeID, string IncludeTickers)
            {
                DerivativesData.DerivativesExchange derivativeExchange = new DerivativesData.DerivativesExchange();

                derivativeExchange = derivativesTasks.GetDerivativesExchangeByID(ExchangeID, IncludeTickers).Result;

                return derivativeExchange;

            }

            /// <summary>
            /// List all derivative exchanges name and identifier
            /// </summary>
            /// <returns></returns>
            public List<DerivativesData.DerivativeExchangeInfoSimple> GetDerivativesExchangesList()
            {
                List<DerivativesData.DerivativeExchangeInfoSimple> list = new List<DerivativesData.DerivativeExchangeInfoSimple>();

                list = derivativesTasks.GetDerivativesExchangesList().Result;

                return list;

            }
        }

        public class MiscMethods : MiscTasks
        {
            MiscTasks miscTasks = new MiscTasks();
            

            /// <summary>
            /// Get BTC-to-Currency exchange rates
            /// </summary>
            /// <returns>List MiscData.ExchangeRate</returns>
            public List<MiscData.ExchangeRate> GetExchangeRates()
            {
                List<MiscData.ExchangeRate> exchangeRateList = new List<MiscData.ExchangeRate>();

                exchangeRateList = miscTasks.GetExchangeRates().Result;
                //exchangeRateList = GetExchangeRates();

                return exchangeRateList;
            }

            /// <summary>
            /// Search for coins, categories and markets listed on CoinGecko ordered by largest Market Cap first
            /// </summary>
            /// <param name="query"></param>
            /// <returns></returns>
            public MiscData.SearchResult Search(string query)
            { 
                MiscData.SearchResult searchResult = new MiscData.SearchResult();

                searchResult = miscTasks.Search(query).Result;

                return searchResult;
            }

            /// <summary>
            /// Top-7 trending coins on CoinGecko as searched by users in the last 24 hours (Ordered by most popular first)
            /// </summary>
            /// <returns></returns>
            public MiscData.TrendingResults Trending()
            { 
                MiscData.TrendingResults trendingResults = new MiscData.TrendingResults();

                trendingResults = miscTasks.Trending().Result;

                return trendingResults;
            }

            /// <summary>
            /// Get cryptocurrency global data
            /// </summary>
            /// <returns></returns>
            public MiscData.CryptoGlobal.GlobalData GetCryptoGlobalData()
            {
                MiscData.CryptoGlobal.GlobalData globalData = new MiscData.CryptoGlobal.GlobalData();

                globalData = miscTasks.GetCryptoGlobalData().Result;    

                return globalData;            
            }
        }

        public string Ping()
        {
            return PingServer().Result;
        }

        internal async Task<string> PingServer()
        { 
            var url = "https://api.coingecko.com/api/v3/ping";
            var response = await httpClient.GetAsync(url);
            string pingResponse = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    pingResponse = JsonConvert.DeserializeObject<string>(content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                var errorMsg = ($"Failed to retrieve data. Status code: {response.StatusCode}");
            }

            return pingResponse;
        }

        #endregion
    }









}