// 425. Word Squares
using System.Text;

public class Solution_425
{
    private readonly TrieNode _root = new ();
    private string[] _words;
    private int _wordLength;

    public IList<IList<string>> WordSquares(string[] words)
    {
        _words = words;
        _wordLength = words[0].Length;

        BuildTrie(words);

        var allSquares = new List<IList<string>>();

        foreach (var word in words)
        {
            var squaresForWord = new List<string>(word.Length);
            squaresForWord.Add(word);
            Backtracking(step: 1, squaresForWord, allSquares);
        }

        return allSquares;
    }

    private void BuildTrie(string[] words)
    {
        for (var wordIndex = 0; wordIndex < words.Length; wordIndex++)
        {
            var node = _root;
            var word = words[wordIndex];

            foreach (var symbol in word)
            {
                if (!node.Children.ContainsKey(symbol))
                {
                    node.Children.Add(symbol, new TrieNode());
                }

                node = node.Children[symbol];
                node.WordIndices.Add(wordIndex);
            }
        }
    }

    private void Backtracking(
        int step, List<string> wordSquares, List<IList<string>> allSquares)
    {
        if (step == _wordLength)
        {
            allSquares.Add(wordSquares.ToList());
            return;
        }

        var prefix = new StringBuilder();

        foreach (var word in wordSquares)
        {
            prefix.Append(word[step]);
        }

        var wordIndices = GetWordIndicesWithPrefix(prefix.ToString());

        foreach (var wordIndex in wordIndices)
        {
            wordSquares.Add(_words[wordIndex]);
            Backtracking(step + 1, wordSquares, allSquares);
            wordSquares.RemoveAt(wordSquares.Count - 1);
        }
    }

    private List<int> GetWordIndicesWithPrefix(string prefix)
    {
        var node = _root;

        foreach (var symbol in prefix)
        {
            if (!node.Children.ContainsKey(symbol))
            {
                return [];
            }

            node = node.Children[symbol];
        }

        return node.WordIndices;
    }

    private class TrieNode
    {
        public readonly Dictionary<char, TrieNode> Children = new();
        public readonly List<int> WordIndices = new();
    }
}