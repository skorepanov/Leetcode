// 188. Best Time to Buy and Sell Stock IV
public class Solution_188
{
    private int[][][] _cache;
    private int _k;
    private int[] _prices;

    public int MaxProfit(int k, int[] prices)
    {
        _k = k;
        _prices = prices;

        InitializeCache();

        return Dp(i: 0, transactionRemaining: k, holding: 0);
    }

    private void InitializeCache()
    {
        _cache = new int[_prices.Length][][];

        for (var i = 0; i < _cache.Length; i++)
        {
            _cache[i] = new int[_k + 1][];

            for (var j = 0; j < _k + 1; j++)
            {
                _cache[i][j] = new int[2];
            }
        }
    }

    private int Dp(int i, int transactionRemaining, int holding)
    {
        if (transactionRemaining == 0 || i == _prices.Length)
        {
            return 0;
        }

        if (_cache[i][transactionRemaining][holding] != 0)
        {
            return _cache[i][transactionRemaining][holding];
        }

        var doNothing = Dp(i + 1, transactionRemaining, holding);

        var doSomething = holding == 1
            ? Dp(i + 1, transactionRemaining - 1, holding: 0) + _prices[i]
            : Dp(i + 1, transactionRemaining, holding: 1) - _prices[i];

        _cache[i][transactionRemaining][holding] = Math.Max(doNothing, doSomething);

        return _cache[i][transactionRemaining][holding];
    }
}