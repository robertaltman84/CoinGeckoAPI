using Newtonsoft.Json;

namespace CoinGeckoAPI.Coin
{
    public class CoinTasks
    {
        #region Variables & Declearations
        private HttpClient httpClient = new HttpClient();
        private CoinData Coin = new CoinData();

        #endregion

        #region Async Tasks
        /// <summary>
        /// Lists all supported coins, id, name and symbol (no pagination required)
        /// Takes optional prameter include_platform
        /// </summary>
        /// <returns></returns>
        internal async Task<List<CoinData>> GetCoinList(bool includePlatform = false)
        {
            var url = "https://api.coingecko.com/api/v3/coins/list?include_platform=" + Convert.ToString(includePlatform);
            var response = await httpClient.GetAsync(url);
            List<CoinData> coinList = new List<CoinData>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    coinList = JsonConvert.DeserializeObject<List<CoinData>>(content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }

            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return coinList;
        }

        /// <summary>
        /// Use this to obtain all the coins market data (price, market cap, volume)
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        internal async Task<List<CoinData>> GetCoinsMarkets(string currency, string ids = "", string category = "",
            string order = "", int per_page = 250, int page = 1, bool sparkline = false, string price_change_percentage = "")
        {

            #region Handle Potentially Non-Used Parameters
            if (string.IsNullOrEmpty(ids))
                ids = "";
            else
                ids = "&ids=" + ids.Replace(",", "%2C%20");

            if (string.IsNullOrEmpty(category))
                category = "";
            else
                category = "&category=" + category;

            if (string.IsNullOrEmpty(order))
                order = "";
            else
                order = "&order=" + order;

            if (string.IsNullOrEmpty(price_change_percentage))
                price_change_percentage = "";
            else
                price_change_percentage = "&price_change_percentage=" + price_change_percentage;

            #endregion

            var url = "https://api.coingecko.com/api/v3/coins/markets?"
                        + "vs_currency=" + currency
                        + ids
                        + category
                        + order
                        + "&per_page=" + Convert.ToString(per_page)
                        + "&page=" + Convert.ToString(page)
                        + "&sparkline=" + Convert.ToString(sparkline)
                        + price_change_percentage;


            var response = await httpClient.GetAsync(url);
            List<CoinData> coinList = new List<CoinData>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    coinList = JsonConvert.DeserializeObject<List<CoinData>>(content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }

            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return coinList;
        }

        /// <summary>
        /// Get current data (name, price, market, ... including exchange tickers) for a coin.
        /// IMPORTANT:
        /// Ticker object is limited to 100 items, to get more tickers, use /coins/{id//}/tickers
        /// Ticker is_stale is true when ticker that has not been updated/unchanged from the exchange for a while.
        /// Ticker is_anomaly is true if ticker's price is outliered by our system.
        /// You are responsible for managing how you want to display these information(e.g.footnote, different background, change opacity, hide)
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        internal async Task<CoinData.Info> GetCoinInformation(string ticker, bool localization = true, bool includeTickerData = true,
            bool includeMarketData = true, bool includeCommunityData = true, bool includeDeveloperData = true, bool sparkline = false)
        {
            var url = "https://api.coingecko.com/api/v3/coins/"
                        + ticker
                        + "?localization=" + Convert.ToString(localization)
                        + "&tickers=" + Convert.ToString(includeTickerData)
                        + "&market_data=" + Convert.ToString(includeMarketData)
                        + "&community_data=" + Convert.ToString(includeCommunityData)
                        + "&developer_data=" + Convert.ToString(includeDeveloperData)
                        + "&sparkline=" + Convert.ToString(sparkline);

            var response = await httpClient.GetAsync(url);
            CoinData.Info coinInfo = new CoinData.Info();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    coinInfo = JsonConvert.DeserializeObject<CoinData.Info>(content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return coinInfo;
        }

        /// <summary>
        /// Get coin tickers (paginated to 100 items)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exchangeIDs"></param>
        /// <param name="include_exchange_logo"></param>
        /// <param name="page"></param>
        /// <param name="order"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        internal async Task<List<CoinData.Tickers>> GetCoinTickers(string id, string exchangeIDs = "", bool include_exchange_logo = false,
            int page = 1, string order = "", bool depth = false)
        {
            #region Handle Potentially Unused Paramers

            if (string.IsNullOrEmpty(exchangeIDs))
                exchangeIDs = "";
            else
                exchangeIDs = "exchange_ids=" + exchangeIDs.Replace(",", "%2C%20");

            #endregion
            var url = "https://api.coingecko.com/api/v3/coins/"
                + id
                + "/tickers?"
                + exchangeIDs
                + "&include_exchange_logo=" + Convert.ToString(include_exchange_logo)
                + "&page=" + Convert.ToString(page)
            + "&order=" + order
                + "&depth=" + Convert.ToString(depth);

            var response = await httpClient.GetAsync(url);
            List<CoinData.Tickers> ticker = new List<CoinData.Tickers>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ticker = JsonConvert.DeserializeObject<List<CoinData.Tickers>>(content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return ticker;
        }

        /// <summary>
        /// Get historical data (price, market cap, 24hr volume, ..) at a given date for a coin.
        /// The data returned is at 00:00:00 UTC.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="localization"></param>
        /// <returns></returns>
        internal async Task<CoinData.HistoricalData> GetCoinHistoricalData(string id, string date, bool localization = false)
        {
            date = string.Format(date, "dd-mm-yyyy");

            var url = "https://api.coingecko.com/api/v3/coins/"
                       + id
                       + "/history?"
                       + "date=" + date
                       + "&localization=" + Convert.ToString(localization);

            var response = await httpClient.GetAsync(url);
            CoinData.HistoricalData historicalData = new CoinData.HistoricalData();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    historicalData = JsonConvert.DeserializeObject<CoinData.HistoricalData>(content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return historicalData;
        }
        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume (granularity auto)
        /// Data granularity is automatic(cannot be adjusted)
        /// 1 day from current time = 5 minute interval data
        /// 1 - 90 days from current time = hourly data
        /// above 90 days from current time = daily data(00:00 UTC)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currency"></param>
        /// <param name="days"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        internal async Task<CoinData.ChartPriceData> GetCoinMarketChartData(string id, string currency, int days, string interval)
        {


            var url = "https://api.coingecko.com/api/v3/coins/"
                        + id
                        + "/market_chart?"
                        + "vs_currency=" + currency
                        + "&days=" + Convert.ToString(days)
                        + "&interval=" + interval;

            var response = await httpClient.GetAsync(url);
            CoinData.ChartPriceData chartPriceData = new CoinData.ChartPriceData();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    chartPriceData = JsonConvert.DeserializeObject<CoinData.ChartPriceData>(content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return chartPriceData;
        }
        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume within a range of timestamp (granularity auto)
        /// Data granularity is automatic(cannot be adjusted)
        /// 1 day from current time = 5 minute interval data
        /// 1 - 90 days from current time = hourly data
        /// above 90 days from current time = daily data(00:00 UTC)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currency"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        internal async Task<CoinData.ChartPriceData> GetCoinMarketChartDataRange(string id, string currency, string fromDate, string toDate)
        {
            fromDate = Convert.ToString((long)Convert.ToDateTime(string.Format(fromDate, "dd-mm-yyyy")).Subtract(DateTime.UnixEpoch).TotalSeconds);
            toDate = Convert.ToString((long)Convert.ToDateTime(string.Format(toDate, "dd-mm-yyyy")).Subtract(DateTime.UnixEpoch).TotalSeconds);

            var url = "https://api.coingecko.com/api/v3/coins/"
                        + id
                        + "/market_chart/range?"
                        + "vs_currency=" + currency
            + "&from=" + fromDate
                        + "&to=" + toDate;

            var response = await httpClient.GetAsync(url);
            CoinData.ChartPriceData chartPriceData = new CoinData.ChartPriceData();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    chartPriceData = JsonConvert.DeserializeObject<CoinData.ChartPriceData>(content);

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return chartPriceData;
        }
        /// <summary>
        /// Candle's body:
        /// 1 - 2 days: 30 minutes
        /// 3 - 30 days: 4 hours
        /// 31 days and beyond: 4 days
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currency"></param>
        /// <param name="days"><Param description="Data up to number of days ago (1/7/14/30/90/180/365/max)"></param>
        /// <returns></returns>
        internal async Task<CoinData.OpenHighLowClose> GetCoinOHLC(string id, string currency, string days)
        {
            string[] validDays = { "1", "7", "14", "30", "90", "180", "365", "max" };
            if (validDays.Contains(days) == false)
                days = "1";

            var url = "https://api.coingecko.com/api/v3/coins/"
                        + id
                        + "/ohlc?"
                        + "vs_currency=" + currency
                        + "&days=" + days;


            var response = await httpClient.GetAsync(url);
            CoinData.OpenHighLowClose openHighLowClose = new CoinData.OpenHighLowClose();
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic cpd = JsonConvert.DeserializeObject<decimal[][]>(content);

                    CoinData.OpenHighLowCloseData[] _allData = new CoinData.OpenHighLowCloseData[cpd.Length];
                    CoinData.OpenHighLowClose ohlc = new CoinData.OpenHighLowClose();

                    int rowCounter = 0;

                    foreach (dynamic row in cpd)
                    {
                        CoinData.OpenHighLowCloseData openHighLowCloseData = new CoinData.OpenHighLowCloseData();
                        openHighLowCloseData.Open = row[0];
                        openHighLowCloseData.High = row[1];
                        openHighLowCloseData.Low = row[2];
                        openHighLowCloseData.Close = row[3];

                        _allData[rowCounter] = openHighLowCloseData;

                        rowCounter++;
                    }
                    ohlc.Data = _allData;
                    openHighLowClose = ohlc;
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                var errorMsg = $"Failed to retrieve data. Status code: {response.StatusCode}";
            }

            return openHighLowClose;
        }

        /// <summary>
        /// Get coin info from contract address
        /// </summary>
        /// <param name="assetPlatformId"></param>
        /// <param name="contractAddress"></param>
        /// <returns></returns>
        internal async Task GetCoinInfoFromContractAddress(string assetPlatformId, string contractAddress)
        {
            string url = "https://api.coingecko.com/api/v3/coins/"
                + assetPlatformId
                + "/contract/"
                + contractAddress;

            //var response = await httpClient.GetAsync(url);

            //if (response.IsSuccessStatusCode)
            //{
            //    try
            //    {
            //        var content = await response.Content.ReadAsStringAsync();
            //        dynamic cpd = JsonConvert.DeserializeObject<List<AssetPlatforms>>(content);

            //        Asset_Platforms = cpd;
            //    }
            //    catch (Exception ex)
            //    {
            //        string msg = ex.Message;
            //    }
            //}
            //else
            //{
            //    var errorMsg = ($"Failed to retrieve data. Status code: {response.StatusCode}");
            //}
        }

        #endregion
    }
}
