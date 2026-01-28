// 518. Coin Change II
public class Solution_518
{
    private int[] _coins;
    private int[][] _cache;

    public int Change(int amount, int[] coins)
    {
        _coins = coins;

        _cache = new int[_coins.Length][];

        for (var i = 0; i < _cache.Length; i++)
        {
            _cache[i] = new int[amount + 1];
            Array.Fill(_cache[i], value: -1);
        }

        return Dp(i: 0, amountLeft: amount);
    }

    private int Dp(int i, int amountLeft)
    {
        if (amountLeft == 0)
        {
            return 1;
        }

        if (i == _coins.Length)
        {
            return 0;
        }

        if (_cache[i][amountLeft] != -1)
        {
            return _cache[i][amountLeft];
        }

        if (_coins[i] > amountLeft)
        {
            _cache[i][amountLeft] = Dp(i + 1, amountLeft);
            return _cache[i][amountLeft];
        }

        _cache[i][amountLeft] = Dp(i, amountLeft - _coins[i])
                              + Dp(i + 1, amountLeft);

        return _cache[i][amountLeft];
    }
}