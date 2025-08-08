// 145. Binary Tree Postorder Traversal

#region Вариант 1 - Рекурсивный
public class Solution_145_1
{
    public IList<int> PostorderTraversal(TreeNode root)
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

        Traverse(node.left, traversal);
        Traverse(node.right, traversal);
        traversal.Add(node.val);
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
public class Solution_145_2
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        if (root is null)
        {
            return new List<int>();
        }

        var traversal = new List<int>();
        var pendingNodes = new Stack<TreeNode>();
        var currentNode = root;

        while (currentNode is not null || pendingNodes.Count > 0)
        {
            if (currentNode is not null)
            {
                traversal.Add(currentNode.val);
                pendingNodes.Push(currentNode);
                currentNode = currentNode.right;
            }
            else
            {
                currentNode = pendingNodes.Pop();
                currentNode = currentNode.left;
            }
        }

        traversal.Reverse();

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
