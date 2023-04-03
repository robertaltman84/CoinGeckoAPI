using Newtonsoft.Json;

namespace CoinGeckoAPI.Indexes
{
    public class IndexesTasks
    {
        #region Variables & Declearations

        private HttpClient httpClient = new HttpClient();


        #endregion

        #region Async Tasks

        /// <summary>
        /// List all market indexes by page number
        /// </summary>
        /// <param name="PerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        internal async Task<List<IndexesData.IndexInfo>> GetIndexesByPage(int PerPage, int PageNumber)
        {
            var url = "https://api.coingecko.com/api/v3/indexes?"
                    + "per_page=" + Convert.ToString(PerPage)
                    + "&page=" + Convert.ToString(PageNumber);

            var response = await httpClient.GetAsync(url);

            List<IndexesData.IndexInfo> indexInfos = new List<IndexesData.IndexInfo>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    indexInfos = JsonConvert.DeserializeObject<List<IndexesData.IndexInfo>>(content);
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

            return indexInfos;
        }
        /// <summary>
        /// get market index by market id and index id
        /// </summary>
        /// <param name="MarketID"></param>
        /// <param name="IndexID"></param>
        /// <returns></returns>
        internal async Task<string> GetIndexesByMakretIDIndexID(string MarketID, string IndexID)
        {
            var url = "https://api.coingecko.com/api/v3/indexes/" 
                           + MarketID 
                           + "/" + IndexID;

            var response = await httpClient.GetAsync(url);

            string toDo = "ToDo: Need to get returned JSON";

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var indexInfos = JsonConvert.DeserializeObject(content);
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

            return toDo;
        }

        /// <summary>
        /// List market indexes id and name
        /// </summary>
        /// <param name="PerPage"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        internal async Task<List<IndexesData.IndexInfoSimple>> GetIndexesList()
        {
            var url = "https://api.coingecko.com/api/v3/indexes/list";

            var response = await httpClient.GetAsync(url);

            List<IndexesData.IndexInfoSimple> indexInfos = new List<IndexesData.IndexInfoSimple>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    indexInfos = JsonConvert.DeserializeObject<List<IndexesData.IndexInfoSimple>>(content);
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

            return indexInfos;
        }

        #endregion
    }
}
