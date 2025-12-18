// 1137. N-th Tribonacci Number
public class Solution_1137
{
    private readonly Dictionary<int, int> _cache = new();

    public int Tribonacci(int n)
    {
        switch (n)
        {
            case 0:
                return 0;
            case 1 or 2:
                return 1;
        }

        if (_cache.TryGetValue(n, out var value))
        {
            return value;
        }

        var currentValue = Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);

        _cache.Add(n, currentValue);

        return currentValue;
    }
}