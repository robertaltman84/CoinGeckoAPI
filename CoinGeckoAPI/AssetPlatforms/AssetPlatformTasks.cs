using Newtonsoft.Json;

namespace CoinGeckoAPI.AssetPlatforms
{
    public class AssetPlatformTasks
    {
        #region Variables & Declearations

        private HttpClient httpClient = new HttpClient();

        #endregion

        #region Async Tasks

        /// <summary>
        /// List all asset platforms (Blockchain networks)
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        internal async Task<AssetPlatformsData> GetAssetPlatforms(string filter = "")
        {
            string url = string.Empty;

            if (string.IsNullOrEmpty(filter))
                url = "https://api.coingecko.com/api/v3/asset_platforms";
            else
                url = "https://api.coingecko.com/api/v3/asset_platforms?" + "filter=" + filter;

            var response = await httpClient.GetAsync(url);
            AssetPlatformsData assetPlatforms = new AssetPlatformsData();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic cpd = JsonConvert.DeserializeObject<List<AssetPlatformsData>>(content);

                    assetPlatforms = cpd;
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

            return assetPlatforms;
        }

        #endregion
    }

}
