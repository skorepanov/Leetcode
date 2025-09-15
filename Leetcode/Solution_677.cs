// 677. Map Sum Pairs

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */

public class MapSum_677
{
    private readonly TrieNode _root = new ();

    public MapSum_677() { }

    public void Insert(string key, int val)
    {
        var node = _root;

        foreach (var symbol in key)
        {
            if (!node.Children.ContainsKey(symbol))
            {
                node.Children.Add(symbol, new TrieNode());
            }

            node = node.Children[symbol];
        }

        node.SetValue(val);
    }

    public int Sum(string prefix)
    {
        var node = _root;

        foreach (var symbol in prefix)
        {
            if (!node.Children.ContainsKey(symbol))
            {
                return 0;
            }

            node = node.Children[symbol];
        }

        var sum = node.Value + SumChildren(node);

        return sum;
    }

    private int SumChildren(TrieNode root)
    {
        var sum = 0;

        foreach (var node in root.Children.Values)
        {
            sum += node.Value;
            sum += SumChildren(node);
        }

        return sum;
    }

    private class TrieNode
    {
        public int Value { get; private set; }
        public readonly Dictionary<char, TrieNode> Children = new();

        public TrieNode() { }

        public void SetValue(int value)
        {
            Value = value;
        }
    }
}
