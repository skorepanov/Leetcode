// 276. Paint Fence

#region Вариант 1 - Top-down - Runtime 0 ms, Beats 100.00%
public class Solution_276_1
{
    private int _n;
    private int _k;
    private int[] _cache;

    public int NumWays(int n, int k)
    {
        _n = n;
        _k = k;

        _cache = new int[n + 1];

        return Dp(i: _n);
    }

    private int Dp(int i)
    {
        if (i == 1)
        {
            return _k;
        }

        if (i == 2)
        {
            return _k * _k;
        }

        if (_cache[i] != 0)
        {
            return _cache[i];
        }

        _cache[i] = (_k - 1) * (Dp(i - 1) + Dp(i - 2));

        return _cache[i];
    }
}
#endregion

#region Вариант 2 - Bottom-up - Runtime 0 ms, Beats 100.00%
public class Solution_276_2
{
    public int NumWays(int n, int k)
    {
        if (n == 1)
        {
            return k;
        }

        var postsBack2 = k;
        var postsBack1 = k * k;

        for (var i = 3; i <= n; i++)
        {
            var currentPosts = (k - 1) * (postsBack2 + postsBack1);

            postsBack2 = postsBack1;
            postsBack1 = currentPosts;
        }

        return postsBack1;
    }
}
#endregion
