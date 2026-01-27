// 322. Coin Change
public class Solution_322
{
    private int[] _cache;
    private int[] _coins;

    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0)
        {
            return 0;
        }

        _coins = coins;
        _cache = new int[amount];

        return Dp(amountLeft: amount);
    }

    private int Dp(int amountLeft)
    {
        if (amountLeft < 0)
        {
            return -1;
        }

        if (amountLeft == 0)
        {
            return 0;
        }

        if (_cache[amountLeft - 1] != 0)
        {
            return _cache[amountLeft - 1];
        }

        var fewestCount = int.MaxValue;

        foreach (var coin in _coins)
        {
            var count = Dp(amountLeft - coin);

            if (count > -1 && count < fewestCount)
            {
                fewestCount = count + 1;
            }
        }

        if (fewestCount == int.MaxValue)
        {
            fewestCount = -1;
        }

        _cache[amountLeft - 1] = fewestCount;

        return _cache[amountLeft - 1];
    }
}