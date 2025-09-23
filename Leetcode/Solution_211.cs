// 211. Design Add and Search Words Data Structure

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */

public class WordDictionary_211
{
    private const char ANY_SYMBOL = '.';
    private readonly TrieNode _root = new ();

    public WordDictionary_211() { }

    public void AddWord(string word)
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

        node.SetAsWord();
    }

    public bool Search(string word)
    {
        return Search(word, _root, index: 0);
    }

    private bool Search(string word, TrieNode node, int index)
    {
        // if not "."
        if (word[index] != ANY_SYMBOL)
        {
            if (!node.Children.TryGetValue(word[index], out var child))
            {
                return false;
            }

            if (index == word.Length - 1)
            {
                return child.IsWord;
            }

            return Search(word, child, index + 1);
        }

        // if "."
        if (index == word.Length - 1)
        {
            return node.Children.Any(c => c.Value.IsWord);
        }

        foreach (var childToSearch in node.Children.Values)
        {
            var isFound = Search(word, childToSearch, index + 1);

            if (isFound)
            {
                return true;
            }
        }

        return false;
    }

    private class TrieNode
    {
        public bool IsWord { get; private set; }
        public readonly Dictionary<char, TrieNode> Children = new ();

        public void SetAsWord()
        {
            IsWord = true;
        }
    }
}
