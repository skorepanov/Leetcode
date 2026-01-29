// 97. Interleaving String
public class Solution_97
{
    private string _s1;
    private string _s2;
    private string _s3;
    private bool?[,] _cache;

    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (string.IsNullOrEmpty(s1))
        {
            return s2 == s3;
        }

        if (string.IsNullOrEmpty(s2))
        {
            return s1 == s3;
        }

        if (string.IsNullOrEmpty(s3))
        {
            return false;
        }

        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        _s1 = s1;
        _s2 = s2;
        _s3 = s3;

        _cache = new bool?[_s1.Length + 1, s2.Length + 1];

        return Dp(i1: 0, i2: 0);
    }

    private bool Dp(int i1, int i2)
    {
        if (i1 == _s1.Length && i2 == _s2.Length)
        {
            return true;
        }

        if (_cache[i1, i2] is not null)
        {
            return _cache[i1, i2].Value;
        }

        var i3 = i1 + i2;

        if (i1 < _s1.Length && _s1[i1] == _s3[i3] && Dp(i1 + 1, i2)
         || i2 < _s2.Length && _s2[i2] == _s3[i3] && Dp(i1, i2 + 1))
        {
            _cache[i1, i2] = true;
            return _cache[i1, i2].Value;
        }

        _cache[i1, i2] = false;
        return _cache[i1, i2].Value;
    }
}