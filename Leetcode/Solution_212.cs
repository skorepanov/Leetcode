// 212. Word Search II
public class Solution_212
{
    private readonly TrieNode _root = new ();
    private readonly List<string> _foundWords = new();

    private readonly int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public IList<string> FindWords(char[][] board, string[] words)
    {
        FillTreeByWords(words);
        FindWords(board);

        return _foundWords;
    }

    private void FillTreeByWords(string[] words)
    {
        foreach (var word in words)
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

            node.SetWord(word);
        }
    }

    private void FindWords(char[][] board)
    {
        for (var rowIndex = 0; board.Length > rowIndex; rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < board[rowIndex].Length; columnIndex++)
            {
                if (_root.Children.ContainsKey(board[rowIndex][columnIndex]))
                {
                    FindWords(_root, board, rowIndex, columnIndex);
                }
            }
        }
    }

    private void FindWords(
        TrieNode parentNode, char[][] board, int rowIndex, int columnIndex)
    {
        var symbol = board[rowIndex][columnIndex];
        var childNode = parentNode.Children[symbol];

        if (childNode.Word != null)
        {
            _foundWords.Add(childNode.Word);
            childNode.RemoveWord();
        }

        board[rowIndex][columnIndex] = '#';

        foreach (var direction in _directions)
        {
            var nextRow = rowIndex + direction[0];
            var nextColumn = columnIndex + direction[1];

            if (0 <= nextRow && nextRow < board.Length
             && 0 <= nextColumn && nextColumn < board[nextRow].Length)
            {
                if (childNode.Children.ContainsKey(board[nextRow][nextColumn]))
                {
                    FindWords(childNode, board, nextRow, nextColumn);
                }
            }
        }

        board[rowIndex][columnIndex] = symbol;

        if (childNode.Children.Count == 0)
        {
            parentNode.Children.Remove(symbol);
        }
    }

    private class TrieNode
    {
        public readonly Dictionary<char, TrieNode> Children = new ();
        public string Word { get; private set; }

        public void SetWord(string word)
        {
            Word = word;
        }

        public void RemoveWord()
        {
            Word = null;
        }
    }
}