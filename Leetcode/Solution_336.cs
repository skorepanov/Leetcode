// 336. Palindrome Pairs
public class Solution_336
{
    private readonly TrieNode _root = new();
    private string[] _words;

    public IList<IList<int>> PalindromePairs(string[] words)
    {
        _words = words;

        BuildBackwardTrie();

        var palindromePairs = FindPalindromePairs();
        return palindromePairs;
    }

    private void BuildBackwardTrie()
    {
        for (var wordId = 0; wordId < _words.Length; wordId++)
        {
            var node = _root;
            var word = _words[wordId];

            var symbolArray = word.ToCharArray();
            Array.Reverse(symbolArray);
            var reversedWord = new string(symbolArray);

            for (var symbolIndex = 0; symbolIndex < word.Length; symbolIndex++)
            {
                if (HasPalindromeRemaining(reversedWord, symbolIndex))
                {
                    node.WordIdsWhenPalindromePrefixRemaining.Add(wordId);
                }

                var symbol = reversedWord[symbolIndex];

                if (!node.Children.ContainsKey(symbol))
                {
                    node.Children.Add(symbol, new TrieNode());
                }

                node = node.Children[symbol];
            }

            node.WordId = wordId;
        }
    }

    private bool HasPalindromeRemaining(string s, int index)
    {
        var left = index;
        var right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    private List<IList<int>> FindPalindromePairs()
    {
        var pairs = new List<IList<int>>();

        for (var wordId = 0; wordId < _words.Length; wordId++)
        {
            var word = _words[wordId];
            var node = _root;

            for (var symbolIndex = 0; symbolIndex < word.Length; symbolIndex++)
            {
                // если префикс слова является палиндромом, н-р, "aba" и ""
                if (node.WordId != null
                 && HasPalindromeRemaining(word, symbolIndex))
                {
                    pairs.Add([wordId, node.WordId.Value]);
                }

                var symbol = word[symbolIndex];

                if (!node.Children.ContainsKey(symbol))
                {
                    node = null;
                    break;
                }

                node = node.Children[symbol];
            }

            if (node is null)
            {
                continue;
            }

            // если нашли полный палиндром, н-р, "abcd" и "dcba"
            if (node.WordId != null && node.WordId != wordId)
            {
                pairs.Add([wordId, node.WordId.Value]);
            }

            // если суффикс слова является палиндромом, н-р, "lls" и "sssll"
            foreach (var otherWordId in node.WordIdsWhenPalindromePrefixRemaining)
            {
                pairs.Add([wordId, otherWordId]);
            }
        }

        return pairs;
    }

    private class TrieNode
    {
        public int? WordId { get; set; }
        public readonly Dictionary<char, TrieNode> Children = new();
        public readonly List<int> WordIdsWhenPalindromePrefixRemaining = new();
    }
}