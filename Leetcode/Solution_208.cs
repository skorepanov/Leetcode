// 208. Implement Trie (Prefix Tree)

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */

#region Вариант 1 - Рекурсивно
public class Trie_208_1
{
    private readonly TrieNode _root = new ();

    public Trie_208_1() { }

    public void Insert(string word)
    {
        Insert(word, _root, index: 0);
    }

    private void Insert(string word, TrieNode root, int index)
    {
        if (!root.Children.TryGetValue(word[index], out var node))
        {
            var isWord = word.Length == index + 1;
            var newNode = new TrieNode(isWord);

            root.Children.Add(word[index], newNode);

            if (isWord)
            {
                return;
            }

            Insert(word, newNode, index + 1);
            return;
        }

        if (word.Length == index + 1)
        {
            node.SetAsWord();
            return;
        }

        Insert(word, node, index + 1);
    }

    public bool Search(string word)
    {
        return Search(word, _root, index: 0);
    }

    private bool Search(string word, TrieNode root, int index)
    {
        if (!root.Children.TryGetValue(word[index], out var node))
        {
            return false;
        }

        if (word.Length == index + 1)
        {
            return node.IsWord;
        }

        return Search(word, node, index + 1);
    }

    public bool StartsWith(string prefix)
    {
        return StartsWith(prefix, _root, index: 0);
    }

    private bool StartsWith(string prefix, TrieNode root, int index)
    {
        if (!root.Children.TryGetValue(prefix[index], out var node))
        {
            return false;
        }

        if (prefix.Length == index + 1)
        {
            return true;
        }

        return StartsWith(prefix, node, index + 1);
    }

    private class TrieNode
    {
        public bool IsWord { get; private set; }
        public readonly Dictionary<char, TrieNode> Children = new();

        public TrieNode() { }

        public TrieNode(bool isWord)
        {
            IsWord = isWord;
        }

        public void SetAsWord()
        {
            IsWord = true;
        }
    }
}
#endregion

#region Вариант 2 - Итеративно
public class Trie_208_2
{
    private readonly TrieNode _root = new ();

    public Trie_208_2() { }

    public void Insert(string word)
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
        var node = _root;

        foreach (var symbol in word)
        {
            if (!node.Children.ContainsKey(symbol))
            {
                return false;
            }

            node = node.Children[symbol];
        }

        return node.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        var node = _root;

        foreach (var symbol in prefix)
        {
            if (!node.Children.ContainsKey(symbol))
            {
                return false;
            }

            node = node.Children[symbol];
        }

        return true;
    }

    private class TrieNode
    {
        public bool IsWord { get; private set; }
        public readonly Dictionary<char, TrieNode> Children = new();

        public TrieNode() { }

        public void SetAsWord()
        {
            IsWord = true;
        }
    }
}
#endregion
