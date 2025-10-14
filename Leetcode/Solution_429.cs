// 429. N-ary Tree Level Order Traversal
public class Solution_429
{
    public IList<IList<int>> LevelOrder(Node root)
    {
        if (root is null)
        {
            return new List<IList<int>>();
        }

        var traversal = new List<IList<int>>();

        var pendingNodes = new Queue<Node>();
        pendingNodes.Enqueue(root);

        while (pendingNodes.Count > 0)
        {
            var levelTraversal = new List<int>();
            var levelNodeCount = pendingNodes.Count;

            for (var i = 0; i < levelNodeCount; i++)
            {
                var currentNode = pendingNodes.Dequeue();
                levelTraversal.Add(currentNode.val);

                if (currentNode.children is null || currentNode.children.Count == 0)
                {
                    continue;
                }

                foreach (var childNode in currentNode.children)
                {
                    pendingNodes.Enqueue(childNode);
                }
            }

            traversal.Add(levelTraversal);
        }

        return traversal;
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