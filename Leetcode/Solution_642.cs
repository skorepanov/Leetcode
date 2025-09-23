// 642. Design Search Autocomplete System
using System.Text;

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */

public class AutocompleteSystem_642
{
    private const char FINISH_SYMBOL = '#';
    private readonly StringBuilder _userInput = new ();
    private readonly TrieNode _root = new ();

    public AutocompleteSystem_642(string[] sentences, int[] times)
    {
        for (var i = 0; i < sentences.Length; i++)
        {
            AddWord(sentences[i], times[i]);
        }
    }

    private void AddWord(string word, int? times = null)
    {
        var node = _root;

        foreach (var symbol in word)
        {
            if (!node.Children.ContainsKey(symbol))
            {
                node.Children.Add(symbol, new TrieNode());
            }

            node = node.Children[symbol];
        }

        if (times != null)
        {
            node.Times = times;
        }
        else
        {
            node.Times = (node.Times ?? 0) + 1;
        }
    }

    public IList<string> Input(char c)
    {
        if (c == FINISH_SYMBOL)
        {
            AddWord(_userInput.ToString());
            _userInput.Clear();

            return [];
        }

        _userInput.Append(c);

        var words = new Dictionary<string, int>();
        Search(_root, index: 0, currentWord: "", words);

        var sortedWords = words
            .OrderByDescending(w => w.Value)
            .ThenBy(w => w.Key)
            .Select(w => w.Key)
            .ToList();

        return sortedWords.Count >= 3
            ? sortedWords.Take(3).ToList()
            : sortedWords;
    }

    private void Search(
        TrieNode node, int index, string currentWord, Dictionary<string, int> foundWords)
    {
        // если нужно делать фильтрацию по пользовательскому вводу
        if (index <= _userInput.Length - 1)
        {
            if (!node.Children.TryGetValue(_userInput[index], out var child))
            {
                return;
            }

            currentWord += _userInput[index];

            if (index == _userInput.Length -1 && child.Times != null)
            {
                foundWords.Add(currentWord, child.Times.Value);
            }

            Search(child, index + 1, currentWord, foundWords);
            return;
        }

        // если нужно искать дальше, после пользовательского ввода
        foreach (var child in node.Children)
        {
            var currentWordForChild = currentWord + child.Key;

            if (child.Value.Times != null)
            {
                foundWords.Add(currentWordForChild, child.Value.Times.Value);
            }

            Search(child.Value, index + 1, currentWordForChild, foundWords);
        }
    }

    private class TrieNode
    {
        public int? Times { get; set; }
        public readonly Dictionary<char, TrieNode> Children = new ();
    }
}
