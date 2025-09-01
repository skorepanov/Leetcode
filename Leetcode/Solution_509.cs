// 509. Fibonacci Number
public class Solution_509
{
    private readonly Dictionary<int, int> _cache = new();

    public int Fib(int n)
    {
        switch (n)
        {
            case 0:
                return 0;
            case 1:
                return 1;
        }

        if (_cache.TryGetValue(n, out var cachedFib))
        {
            return cachedFib;
        }

        var fib = Fib(n - 1) + Fib(n - 2);

        _cache.Add(n, fib);

        return fib;
    }
}