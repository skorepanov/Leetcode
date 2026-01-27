// 309. Best Time to Buy and Sell Stock with Cooldown
public class Solution_309
{
    private int[][] _cache;
    private int[] _prices;

    public int MaxProfit(int[] prices)
    {
        _prices = prices;

        InitializeCache();

        return Dp(i: 0, holding: 0);
    }

    private void InitializeCache()
    {
        _cache = new int[_prices.Length][];

        for (var i = 0; i < _cache.Length; i++)
        {
            _cache[i] = new int[2];
        }
    }

    private int Dp(int i, int holding)
    {
        if (i >= _prices.Length)
        {
            return 0;
        }

        if (_cache[i][holding] != 0)
        {
            return _cache[i][holding];
        }

        var doNothing = Dp(i + 1, holding);

        var doSomething = holding == 1
            ? Dp(i + 2, holding: 0) + _prices[i]
            : Dp(i + 1, holding: 1) - _prices[i];

        _cache[i][holding] = Math.Max(doNothing, doSomething);

        return _cache[i][holding];
    }
}