// 589. N-ary Tree Preorder Traversal
public class Solution_589
{
    public IList<int> Preorder(Node root)
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

        traversal.Add(node.val);

        foreach (var nodeChild in node.children)
        {
            Traverse(nodeChild, traversal);
        }
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