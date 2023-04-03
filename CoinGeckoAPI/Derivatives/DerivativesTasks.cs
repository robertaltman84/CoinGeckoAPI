using Newtonsoft.Json;

namespace CoinGeckoAPI.Derivatives
{
    public class DerivativesTasks
    {
        #region Variables & Declearations

        private HttpClient httpClient = new HttpClient();


        #endregion

        #region Async Tasks

        /// <summary>
        /// List all derivative tickers
        /// </summary>
        /// <param name="includeTickers"></param>
        /// <returns></returns>
        internal async Task<List<DerivativesData.DerivativeInfo>> GetAllDerivatives(string includeTickers = "false")
        {
            var url = "https://api.coingecko.com/api/v3/derivatives?"
                        +"include_tickers=" + includeTickers;

            var response = await httpClient.GetAsync(url);

            List<DerivativesData.DerivativeInfo> derivativesInfos = new List<DerivativesData.DerivativeInfo>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    derivativesInfos = JsonConvert.DeserializeObject<List<DerivativesData.DerivativeInfo>>(content);
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

            return derivativesInfos;
        }

        /// <summary>
        /// List all derivative exchanges
        /// </summary>
        /// <param name="order"></param>
        /// <param name="perPage"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        internal async Task<List<DerivativesData.DerivativeExchangeInfo>> GetDerivativeExchangeInfos(string Order = "name_asc", int PerPage = 100, int Page = 1)
        {
            var url = "https://api.coingecko.com/api/v3/derivatives/exchanges?"
                            + "order=" + Order
                            + "&per_page=" + Convert.ToString(PerPage)
                            + "&page=" + Convert.ToString(Page);

            var response = await httpClient.GetAsync(url);

            List<DerivativesData.DerivativeExchangeInfo> derivativeExchangeInfo = new List<DerivativesData.DerivativeExchangeInfo>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    derivativeExchangeInfo = JsonConvert.DeserializeObject<List<DerivativesData.DerivativeExchangeInfo>>(content);
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

            return derivativeExchangeInfo;
        }

        /// <summary>
        /// Show derivative exchange data by exchange ID
        /// </summary>
        /// <param name="exchangeID"></param>
        /// <param name="includeTickers"></param>
        /// <returns></returns>
        internal async Task<DerivativesData.DerivativesExchange> GetDerivativesExchangeByID(string exchangeID, string includeTickers)
        {
            var url = "https://api.coingecko.com/api/v3/derivatives/exchanges/" 
                                + exchangeID  
                                + "?include_tickers=" + includeTickers;

            var response = await httpClient.GetAsync(url);

            DerivativesData.DerivativesExchange derivativeExchange = new DerivativesData.DerivativesExchange();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    derivativeExchange = JsonConvert.DeserializeObject<DerivativesData.DerivativesExchange>(content);
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

            return derivativeExchange;
        }

        /// <summary>
        /// List all derivative exchanges name and identifier
        /// </summary>
        /// <returns></returns>
        internal async Task<List<DerivativesData.DerivativeExchangeInfoSimple>> GetDerivativesExchangesList()
        {
            var url = "https://api.coingecko.com/api/v3/derivatives/exchanges/list";

            var response = await httpClient.GetAsync(url);

            List<DerivativesData.DerivativeExchangeInfoSimple> list = new List<DerivativesData.DerivativeExchangeInfoSimple>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<DerivativesData.DerivativeExchangeInfoSimple>>(content);
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

            return list;
        }

        #endregion
    }
}
