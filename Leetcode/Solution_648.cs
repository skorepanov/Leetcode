// 648. Replace Words
using System.Text;

public class Solution_648
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        var dictionaryTrie = new Trie();

        foreach (var word in dictionary)
        {
            dictionaryTrie.Insert(word);
        }

        var sentenceWords = sentence.Split(' ');
        var sentenceWordMap = new Dictionary<string, string>();
        var mappedSentence = new StringBuilder();

        foreach (var word in sentenceWords)
        {
            if (!sentenceWordMap.ContainsKey(word))
            {
                var mappedWord = dictionaryTrie.FindPrefix(word);

                if (!string.IsNullOrWhiteSpace(mappedWord))
                {
                    sentenceWordMap.Add(word, mappedWord);
                }
                else
                {
                    sentenceWordMap.Add(word, word);
                }
            }

            if (mappedSentence.Length > 0)
            {
                mappedSentence.Append(' ');
            }

            mappedSentence.Append(sentenceWordMap[word]);
        }

        return mappedSentence.ToString();
    }

    private class Trie
    {
        private readonly TrieNode _root = new ();

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

        public string FindPrefix(string word)
        {
            var prefix = new StringBuilder();
            var node = _root;

            foreach (var symbol in word)
            {
                if (!node.Children.ContainsKey(symbol))
                {
                    return string.Empty;
                }

                node = node.Children[symbol];
                prefix.Append(symbol);

                if (node.IsWord)
                {
                    return prefix.ToString();
                }
            }

            return node.IsWord
                ? prefix.ToString()
                : string.Empty;
        }

        private class TrieNode
        {
            public bool IsWord { get; private set; }
            public readonly Dictionary<char, TrieNode> Children = new();

            public void SetAsWord()
            {
                IsWord = true;
            }
        }
    }
}