// 139. Word Break
public class Solution_139
{
    private bool?[] _cache;
    private string _s;
    private IList<string> _wordDict;

    public bool WordBreak(string s, IList<string> wordDict)
    {
        _s = s;
        _wordDict = wordDict;
        _cache = new bool?[s.Length];

        return Dp(s.Length - 1);
    }

    private bool Dp(int i)
    {
        if (i < 0)
        {
            return true;
        }

        if (_cache[i] is null)
        {
            foreach (var word in _wordDict)
            {
                if (i < word.Length - 1 || !Dp(i - word.Length))
                {
                    continue;
                }

                var isLeftSubstringEqualsToWord = _s
                    .Substring(
                        startIndex: i - word.Length + 1,
                        length: word.Length)
                    .Equals(word);

                if (isLeftSubstringEqualsToWord)
                {
                    _cache[i] = true;
                    break;
                }
            }
        }

        if (_cache[i] is null)
        {
            _cache[i] = false;
        }

        return _cache[i] is true;
    }
}