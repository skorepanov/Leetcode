// 559. Maximum Depth of N-ary Tree
public class Solution_559
{
    public int MaxDepth(Node root)
    {
        if (root is null)
        {
            return 0;
        }

        return MaxDepth(root, currentDepth: 1, maxDepth: 1);
    }

    private int MaxDepth(Node node, int currentDepth, int maxDepth)
    {
        maxDepth = Math.Max(currentDepth, maxDepth);

        if (node.children is null || node.children.Count == 0)
        {
            return maxDepth;
        }

        foreach (var child in node.children)
        {
            var childMaxDepth = MaxDepth(child, currentDepth + 1, maxDepth);
            maxDepth = Math.Max(maxDepth, childMaxDepth);
        }

        return maxDepth;
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}