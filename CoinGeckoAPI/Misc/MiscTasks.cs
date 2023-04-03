using Newtonsoft.Json;

namespace CoinGeckoAPI.Misc
{
    public class MiscTasks: MiscData
    {
        #region Variables & Declearations

        private HttpClient httpClient = new HttpClient();


        #endregion

        #region Async Tasks

        /// <summary>
        /// Get BTC-to-Currency exchange rates
        /// </summary>
        /// <returns></returns>
        internal async Task<List<MiscData.ExchangeRate>> GetExchangeRates()
        {
            var url = "https://api.coingecko.com/api/v3/exchange_rates";

            var response = await httpClient.GetAsync(url);

            List<MiscData.ExchangeRate> exchangeRageList = new List<MiscData.ExchangeRate>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic allRates = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(content);

                    foreach (dynamic rateRoot in allRates)
                    {
                        foreach (dynamic coin in rateRoot.Value)
                        {
                            MiscData.ExchangeRate exchangeRate = new MiscData.ExchangeRate();

                            foreach (dynamic rate in coin.Value)
                            {
                                if (rate.Key == "name")
                                    exchangeRate.CoinName = rate.Value;
                                else if (rate.Key == "unit")
                                    exchangeRate.Unit = rate.Value;
                                else if (rate.Key == "value")
                                    exchangeRate.Rate = float.Parse(rate.Value);
                                else if (rate.Key == "type")
                                    exchangeRate.Type = rate.Value;
                            }

                            exchangeRageList.Add(exchangeRate);
                        }
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
            
            return exchangeRageList;
        }

        /// <summary>
        /// Search for coins, categories and markets listed on CoinGecko ordered by largest Market Cap first
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal async Task<MiscData.SearchResult> Search(string query)
        {
            var url = "https://api.coingecko.com/api/v3/search"
                            + "?query=" + query;

            var response = await httpClient.GetAsync(url);

            MiscData.SearchResult searchResult = new MiscData.SearchResult();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<MiscData.SearchResult>(content);

                    searchResult = result;
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

            return searchResult;
        }

        /// <summary>
        /// Top-7 trending coins on CoinGecko as searched by users in the last 24 hours (Ordered by most popular first)
        /// </summary>
        /// <returns></returns>
        internal async Task<MiscData.TrendingResults> Trending()
        {
            var url = "https://api.coingecko.com/api/v3/search/trending";

            var response = await httpClient.GetAsync(url);

            MiscData.TrendingResults trendingResult = new MiscData.TrendingResults();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<MiscData.TrendingResults>(content);

                    trendingResult = result;
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

            return trendingResult;
        }

        /// <summary>
        /// Get cryptocurrency global data
        /// </summary>
        /// <returns></returns>
        internal async Task<MiscData.CryptoGlobal.GlobalData> GetCryptoGlobalData()
        {
            var url = "https://api.coingecko.com/api/v3/global";

            var response = await httpClient.GetAsync(url);

            MiscData.CryptoGlobal.GlobalData cryptoGlobal = new MiscData.CryptoGlobal.GlobalData();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<MiscData.CryptoGlobal>(content);
                    
                    cryptoGlobal = result.Data;
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

            return cryptoGlobal;
        }


        #endregion
    }
}
