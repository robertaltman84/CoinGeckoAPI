using Newtonsoft.Json;

namespace CoinGeckoAPI.Simple
{
    public class SimpleTasks
    {
        #region Variables & Declearations
        private HttpClient httpClient = new HttpClient();
        #endregion

        #region Async Tasks
        /// <summary>
        /// Get the price of any cryptocurrencies in any other supported currencies that you need
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="currencies"></param>
        /// <param name="precision"></param>
        /// <param name="include_market_cap"></param>
        /// <param name="include_24hr_vol"></param>
        /// <param name="include_24hr_change"></param>
        /// <param name="include_last_updated_at"></param>
        /// <returns></returns>
        internal async Task<List<SimpleData.SimplePrice>> GetPrice(string ids, string currencies, int precision, bool include_market_cap = false, bool include_24hr_vol = false, bool include_24hr_change = false, bool include_last_updated_at = false)
        {
            List<SimpleData.SimplePrice> prices = new List<SimpleData.SimplePrice>();

            ids = ids.Replace(" ", "").Replace(",", "%2C");
            currencies = currencies.Replace(" ", "").Replace(",", "%2C");

            var url = "https://api.coingecko.com/api/v3/simple/price?ids="
                + ids
                + "&vs_currencies=" + currencies
                + "&include_market_cap=" + Convert.ToString(include_market_cap)
                + "&include_24hr_vol=" + Convert.ToString(include_24hr_vol)
                + "&include_24hr_change=" + Convert.ToString(include_24hr_change)
                + "&include_last_updated_at=" + Convert.ToString(include_last_updated_at)
                + "&precision" + Convert.ToString(precision);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var coinPrices = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(content);

                    int coinCounter = 0;



                    foreach (KeyValuePair<string, Dictionary<string, float>> coin in coinPrices)
                    {
                        coinCounter++;

                        SimpleData.SimplePrice simplePrice = new SimpleData.SimplePrice();
                        simplePrice.CoinID = coin.Key;

                        foreach (KeyValuePair<string, float> coinInfo in coin.Value)
                        {
                            simplePrice.Currency = coinInfo.Key;
                            simplePrice.Last = coinInfo.Value;

                            prices.Add(simplePrice);
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

            return prices;
        }
        /// <summary>
        /// Get list of supported vs currencies
        /// </summary>
        /// <returns></returns>
        internal async Task<List<string>> GetSupportedVsCurrencies()
        {
            List<string> currenciesList = new List<string>();

            var url = "https://api.coingecko.com/api/v3/simple/supported_vs_currencies";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();

                    currenciesList = JsonConvert.DeserializeObject<List<string>>(content);
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

            return currenciesList;
        }

        //internal async Task GetPriceByContractAddress()
        //{


        //    var url = "https://api.coingecko.com/api/v3/simple/supported_vs_currencies";

        //    var response = await httpClient.GetAsync(url);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        try
        //        {
        //            var content = await response.Content.ReadAsStringAsync();

        //            var prices = JsonConvert.DeserializeObject<List<string>>(content);
        //        }
        //        catch (Exception ex)
        //        {
        //            string msg = ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        var errorMsg = ($"Failed to retrieve data. Status code: {response.StatusCode}");
        //    }


        //}

        #endregion
    }
}
