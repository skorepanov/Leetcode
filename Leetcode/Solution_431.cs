// 431. Encode N-ary Tree to Binary Tree
public class Codec_431
{
    // Encodes an n-ary tree to a binary tree.
    public TreeNode encode(Node root)
    {
        if (root is null)
        {
            return null;
        }

        var binaryRoot = new TreeNode(root.val);

        var binaryNode = binaryRoot;
        binaryNode.left = new TreeNode(root.children?.Count ?? 0);

        var pendingNaryNodes = new Queue<Node>();
        pendingNaryNodes.Enqueue(root);

        while (pendingNaryNodes.Count > 0)
        {
            var levelNaryNodeCount = pendingNaryNodes.Count;

            for (var i = 0; i < levelNaryNodeCount; i++)
            {
                var currentNaryNode = pendingNaryNodes.Dequeue();

                if (currentNaryNode.children is null
                 || currentNaryNode.children.Count == 0)
                {
                    continue;
                }

                foreach (var naryChild in currentNaryNode.children)
                {
                    pendingNaryNodes.Enqueue(naryChild);

                    binaryNode.right = new TreeNode(naryChild.val);
                    binaryNode = binaryNode.right;

                    if (naryChild.children?.Count > 0)
                    {
                        binaryNode.left = new TreeNode(naryChild.children.Count);
                    }
                }
            }
        }

        return binaryRoot;
    }

    // Decodes your binary tree to an n-ary tree.
    public Node decode(TreeNode root)
    {
        if (root is null)
        {
            return null;
        }

        var naryRoot = new Node(root.val, _children: []);

        if (root.left is null || root.left?.val == 0)
        {
            return naryRoot;
        }

        var currentBinaryNode = root;

        var pendingNaryNodes = new Queue<(Node, int)>();
        pendingNaryNodes.Enqueue((naryRoot, root.left.val));

        while (pendingNaryNodes.Count > 0)
        {
            var (currentNaryNode, childCount) = pendingNaryNodes.Dequeue();

            for (var i = 0; i < childCount; i++)
            {
                currentBinaryNode = currentBinaryNode.right;

                var naryChildNode = new Node(currentBinaryNode.val, _children: []);
                currentNaryNode.children.Add(naryChildNode);

                if (currentBinaryNode.left?.val > 0)
                {
                    pendingNaryNodes.Enqueue((naryChildNode, currentBinaryNode.left.val));
                }
            }
        }

        return naryRoot;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
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