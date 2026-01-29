// 1143. Longest Common Subsequence
public class Solution_1143
{
    private string _text1;
    private string _text2;
    private int[][] _cache;

    public int LongestCommonSubsequence(string text1, string text2)
    {
        _text1 = text1;
        _text2 = text2;

        _cache = new int[_text1.Length][];

        for (var i = 0; i < _text1.Length; i++)
        {
            _cache[i] = new int[_text2.Length];
            Array.Fill(_cache[i], value: -1);
        }

        return Dp(text1Index: 0, text2Index: 0);
    }

    private int Dp(int text1Index, int text2Index)
    {
        if (text1Index >= _text1.Length
         || text2Index >= _text2.Length)
        {
            return 0;
        }

        if (_cache[text1Index][text2Index] != -1)
        {
            return _cache[text1Index][text2Index];
        }

        int answer;

        if (_text1[text1Index] == _text2[text2Index])
        {
            answer = Dp(text1Index + 1, text2Index + 1) + 1;
        }
        else
        {
            var option1 = Dp(text1Index + 1, text2Index);
            var option2 = Dp(text1Index, text2Index + 1);

            answer = Math.Max(option1, option2);
        }

        _cache[text1Index][text2Index] = answer;

        return _cache[text1Index][text2Index];
    }
}