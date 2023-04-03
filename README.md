# CoinGeckoAPI
C# wrapper for the <a href="https://www.coingecko.com/en/api">CoinGeco API</a>

# There are many like it, but this one is mine.
Even tho there are plenty of libraries out there that do the same thing, I had trouble getting them to work for me so I created my own.

# Available API Services
The services currently still in BETA are not yet available.
All other services/request are working. 
There are classes for each section or category of calls (i.e. CoinMethods) which are accessible via CoinGeckoAPIClient.

  The <a href = "https://www.coingecko.com/en/api/documentation">guide provided by CoinGecko</a> is very useful in determining which methods to use, and what arguments are required.

# Usage Example:
(leading +/! only for color formatting)
  ```diff
  + CoinGeckoAPIClient.CoinMethods CoinMethods = new CoinGeckoAPIClient.CoinMethods();

  + List<CoinData> CoinList = new List<CoinData>(coinMethods.GetCoinList());

  !//OR//
 
  + var CoinList = CoinMethods.GetCoinList();
   ```

# Future Improvements

* Create library for arguments that aren't straight forward (i.e. "Order" is currently a string value like "market_cap_desc"). 
  For example, Method(string Order) would become Method(SortOrder Order). 
  

  
