// 70. Climbing Stairs
public class Solution_70
{
    private readonly Dictionary<int, int>  _cache = new();

    public int ClimbStairs(int n)
    {
        switch (n)
        {
            case 1:
                return 1;
            case 2:
                return 2;
        }

        if (_cache.TryGetValue(n, out var cachedCount))
        {
            return cachedCount;
        }

        var count = ClimbStairs(n - 1) + ClimbStairs(n - 2);

        _cache.Add(n, count);

        return count;
    }
}