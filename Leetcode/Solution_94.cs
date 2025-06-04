// 94. Binary Tree Inorder Traversal

#region 1 вариант - Рекурсивный - Runtime 0 ms, Beats 100%
public class Solution_94_1
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        if (root is null)
        {
            return new List<int>();
        }

        var traversal = new List<int>();

        Traverse(root, traversal);

        return traversal;
    }

    private void Traverse(TreeNode root, List<int> traversal)
    {
        if (root is null)
        {
            return;
        }

        if (root.left is not null)
        {
            Traverse(root.left, traversal);
        }

        traversal.Add(root.val);

        if (root.right is not null)
        {
            Traverse(root.right, traversal);
        }
    }

    // Definition for a binary tree node.
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

#region 2 вариант - Итеративный - мой вариант - Runtime 3 ms, Beats 1.68%
public class Solution_94_2
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        if (root is null)
        {
            return new List<int>();
        }

        var traversal = new List<TreeNode>();

        TraverseNode(root.left, traversal);
        traversal.Add(root);
        TraverseNode(root.right, traversal);

        return traversal.Select(t => t.val).ToList();
    }

    private void TraverseNode(TreeNode root, List<TreeNode> traversal)
    {
        if (root is null)
        {
            return;
        }

        var pendingNodes = new Stack<TreeNode>();
        pendingNodes.Push(root);

        while (pendingNodes.Count > 0)
        {
            var node = pendingNodes.Pop();

            if (node.left is not null && !traversal.Contains(node.left))
            {
                pendingNodes.Push(node);
                pendingNodes.Push(node.left);
                continue;
            }

            traversal.Add(node);

            if (node.right is not null)
            {
                pendingNodes.Push(node.right);
            }
        }
    }

    // Definition for a binary tree node.
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

#region 3 вариант - Итеративный - вариант LeetCode - Runtime 0 ms, Beats 100%
public class Solution_94_3
{
    public IList<int> InorderTraversal(TreeNode root)
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
            while (currentNode is not null)
            {
                pendingNodes.Push(currentNode);
                currentNode = currentNode.left;
            }

            currentNode = pendingNodes.Pop();
            traversal.Add(currentNode.val);
            currentNode = currentNode.right;
        }

        return traversal;
    }

    // Definition for a binary tree node.
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