// 144. Binary Tree Preorder Traversal

#region Вариант 1 - Рекурсивный - Runtime 0 ms, Beats 100%
public class Solution_144_1
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var traversal = new List<int>();

        Traverse(root, traversal);

        return traversal;
    }

    private void Traverse(TreeNode node, List<int> traversal)
    {
        if (node is null)
        {
            return;
        }

        traversal.Add(node.val);

        Traverse(node.left, traversal);
        Traverse(node.right, traversal);
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
}
#endregion

#region Вариант 2 - Итеративный
public class Solution_144_2
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root is null)
        {
            return [];
        }

        var traversal = new List<int>();

        var pendingNodes = new Stack<TreeNode>();
        pendingNodes.Push(root);

        TreeNode currentNode;

        while (pendingNodes.Count > 0)
        {
            currentNode = pendingNodes.Pop();
            traversal.Add(currentNode.val);

            if (currentNode.right is not null)
            {
                pendingNodes.Push(currentNode.right);
            }

            if (currentNode.left is not null)
            {
                pendingNodes.Push(currentNode.left);
            }
        }

        return traversal;
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
}
#endregion
