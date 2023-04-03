using Newtonsoft.Json;

namespace CoinGeckoAPI.Indexes
{
    public class IndexesData
    {

        public struct IndexInfo
        { 
            public string Name { get; set; }
            public string ID { get; set; }
            public string Market { get; set; }
            public float Last { get; set; }

            [JsonProperty("is_multi_asset_composite")]
            public bool? IsMultipAssetComposite { get; set; }
        }

        public struct IndexInfoSimple
        {
            public string Name { get; set; }
            public string ID { get; set; }
        }
    }
}
