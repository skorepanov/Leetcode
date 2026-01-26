// 1143. Longest Common Subsequence
public class Solution_1143
{
    private int[][] _cache;
    private string _text1;
    private string _text2;

    public int LongestCommonSubsequence(string text1, string text2)
    {
        _text1 = text1;
        _text2 = text2;

        InitializeCache();

        return Dp(i: 0, j: 0);
    }

    private void InitializeCache()
    {
        _cache = new int[_text1.Length][];

        for (var i = 0; i < _text1.Length; i++)
        {
            _cache[i] = new int[_text2.Length];

            for (var j = 0; j < _text2.Length; j++)
            {
                _cache[i][j] = -1;
            }
        }
    }

    private int Dp(int i, int j)
    {
        if (i >= _text1.Length || j >= _text2.Length)
        {
            return 0;
        }

        if (_cache[i][j] != -1)
        {
            return _cache[i][j];
        }

        int answer;

        if (_text1[i] == _text2[j])
        {
            answer = Dp(i + 1, j + 1) + 1;
        }
        else
        {
            var option1 = Dp(i + 1, j);
            var option2 = Dp(i, j + 1);
            answer = Math.Max(option1, option2);
        }

        _cache[i][j] = answer;

        return _cache[i][j];
    }
}