namespace CoinGeckoAPI.Simple
{
    public class SimpleData
    {

        public struct SupportedVsCurrencies
        {
            public List<string> Currencies { get; set; }
        }

        public struct SimplePrice
        {
            public string CoinID { get; set; }
            public string Currency { get; set; }
            public float Last { get; set; }
        }


    }
}
