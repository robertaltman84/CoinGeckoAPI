using Newtonsoft.Json;

namespace CoinGeckoAPI.AssetPlatforms
{
    public class AssetPlatformsData
    {
        #region Asset Platform

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("chain_identifier")]
        public string ChainIdentifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortname")]
        public string ShortName { get; set; }

        #endregion
    }
}
