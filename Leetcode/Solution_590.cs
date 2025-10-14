// 590. N-ary Tree Postorder Traversal
public class Solution_590
{
    public IList<int> Postorder(Node root)
    {
        var traversal = new List<int>();
        Traverse(root, traversal);
        return traversal;
    }

    private void Traverse(Node node, List<int> traversal)
    {
        if (node is null)
        {
            return;
        }

        foreach (var child in node.children)
        {
            Traverse(child, traversal);
        }

        traversal.Add(node.val);
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