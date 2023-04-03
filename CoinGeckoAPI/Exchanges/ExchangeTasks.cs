using Newtonsoft.Json;
using static CoinGeckoAPI.Exchanges.ExchangeData;

namespace CoinGeckoAPI.Exchanges
{
    public class ExchangeTasks 
    {
        #region Variables & Declearations
        private HttpClient httpClient = new HttpClient();
        #endregion

        #region Async Tasks

        /// <summary>
        /// List all exchanges (Active with trading volumes)
        /// </summary>
        /// <param name="perpage"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        internal async Task<List<Exchange>> GetExchanges(int perpage, int page)
        {
            List<Exchange> exchangeList = new List<Exchange>();

            var url = "https://api.coingecko.com/api/v3/exchanges"
                        + "?per_page=" + Convert.ToString(perpage)
            + "&page=" + Convert.ToString(page);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<Exchange>>(content);
                    exchangeList = result;
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

            return exchangeList;
        }
        /// <summary>
        /// List all supported makrets id and name (no pagination required)
        /// </summary>
        /// <returns></returns>
        internal async Task<List<ExchangeInfo>> GetExchangesList()
        {

            var url = "https://api.coingecko.com/api/v3/exchanges/list";

            var response = await httpClient.GetAsync(url);

            List<ExchangeInfo> exchangelist = new List<ExchangeInfo>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var exchanges = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(content);

                    foreach (Dictionary<string, string> exchange in exchanges)
                    {
                        ExchangeInfo exchangeInformation = new ExchangeInfo();

                        foreach (KeyValuePair<string, string> exchangeInfo in exchange)
                        {
                            if (exchangeInfo.Key == "id")
                                exchangeInformation.ID = exchangeInfo.Value;
                            else if (exchangeInfo.Key == "name")
                                exchangeInformation.Name = exchangeInfo.Value;
                        }

                        exchangelist.Add(exchangeInformation);
                    }
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

            return exchangelist;
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
        internal async Task<ExchangeInfoFull> GetExchangeInfoFull(string ExchangeID)
        {

            var url = "https://api.coingecko.com/api/v3/exchanges/"
                        + ExchangeID;

            var response = await httpClient.GetAsync(url);

            ExchangeInfoFull exchangeInfoFull = new ExchangeInfoFull();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    exchangeInfoFull = JsonConvert.DeserializeObject<ExchangeInfoFull>(content);
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

            return exchangeInfoFull;


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
        internal async Task<ExchangeTickerList> GetExchangeTickers(string ExchangeID, int Page, string CoinIDs, bool IncludeExchangeLogo, bool ShowDepth, string Order)
        {
            CoinIDs = CoinIDs.Replace(",", "%2C");


            var url = "https://api.coingecko.com/api/v3/exchanges/"
                        + ExchangeID
                        + "/tickers?" + CoinIDs
                        + "&include_exchange_logo=" + Convert.ToString(IncludeExchangeLogo)
                        + "&page=" + Convert.ToString(Page)
                        + "&depth=" + Convert.ToString(ShowDepth)
                        + "&order=" + Order;

            var response = await httpClient.GetAsync(url);

            ExchangeTickerList exchangeTickerList = new ExchangeTickerList();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    exchangeTickerList = JsonConvert.DeserializeObject<ExchangeTickerList>(content);

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

            return exchangeTickerList;
        }

        /// <summary>
        /// Get volume_chart data (in BTC) for a given exchange 
        /// </summary>
        /// <param name="ExchangeID"></param>
        /// <param name="Days"></param>
        /// <returns></returns>
        internal async Task<List<ExchangeData.ExchangeVolumeChart>> GetExchangeVolumeChartData(string ExchangeID, int Days)
        {
            var url = "https://api.coingecko.com/api/v3/exchanges/"
                 + ExchangeID
                 + "/volume_chart?"
                 + "days=" + Convert.ToString(Days);


            var response = await httpClient.GetAsync(url);

            List<ExchangeData.ExchangeVolumeChart> volumeChartList = new List<ExchangeData.ExchangeVolumeChart>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    object[][] result = JsonConvert.DeserializeObject<object[][]>(content);

                    foreach (object[] chartData in result)
                    {
                        ExchangeData.ExchangeVolumeChart exchangeVolumeChartHelper = new ExchangeData.ExchangeVolumeChart();

                        exchangeVolumeChartHelper.TimeStamp = float.Parse(chartData[0].ToString());
                        exchangeVolumeChartHelper.Volume = chartData[1].ToString();

                        volumeChartList.Add(exchangeVolumeChartHelper);
                    }
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

            return volumeChartList;
        }

        /// <summary>
        /// Get volume_chart data (in BTC) for a given exchange by date range
        /// </summary>
        /// <param name="ExchangeID"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        internal async Task<List<ExchangeVolumeChart>> GetExchangeVolumeChartDataRange(string ExchangeID, string FromDate, string ToDate)
        {
            var url = "https://api.coingecko.com/api/v3/exchanges/1bch/volume_chart/range?from=1672613003&to=1675291403"
                 + ExchangeID
                 + "/volume_chart/range?"
                 + "from=" + Convert.ToString(FromDate)
                 + "&to=" + Convert.ToString(ToDate);


            var response = await httpClient.GetAsync(url);

            List<ExchangeVolumeChart> volumeChartList = new List<ExchangeVolumeChart>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    volumeChartList = JsonConvert.DeserializeObject<List<ExchangeVolumeChart>>(content);
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

            return volumeChartList;
        }
        #endregion
    }
}
