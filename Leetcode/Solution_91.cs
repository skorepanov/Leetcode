// 91. Decode Ways
public class Solution_91
{
    private string _s;
    private int[] _cache;

    public int NumDecodings(string s)
    {
        _s = s;

        _cache = new int[s.Length];
        Array.Fill(_cache, value: -1);

        return Dp(i: 0);
    }

    private int Dp(int i)
    {
        if (i == _s.Length)
        {
            return 1;
        }

        if (_s[i] == '0')
        {
            return 0;
        }

        if (i == _s.Length - 1)
        {
            return 1;
        }

        if (_cache[i] != -1)
        {
            return _cache[i];
        }

        var count = Dp(i + 1);

        var numberAsString = _s.Substring(startIndex: i, length: 2);
        var number = int.Parse(numberAsString);

        if (number <= 26)
        {
            count += Dp(i + 2);
        }

        _cache[i] = count;

        return _cache[i];
    }
}