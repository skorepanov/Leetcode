// 102. Binary Tree Level Order Traversal
public class Solution_102
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root is null)
        {
            return [];
        }

        var traversal = new List<IList<int>>();
        var pendingNodes = new Queue<TreeNode>();

        pendingNodes.Enqueue(root);

        while (pendingNodes.Count > 0)
        {
            var queueLength = pendingNodes.Count;
            var currentLevelValues = new List<int>();
            TreeNode currentNode;

            while (queueLength > 0)
            {
                currentNode = pendingNodes.Dequeue();
                currentLevelValues.Add(currentNode.val);

                if (currentNode.left is not null)
                {
                    pendingNodes.Enqueue(currentNode.left);
                }

                if (currentNode.right is not null)
                {
                    pendingNodes.Enqueue(currentNode.right);
                }

                queueLength--;
            }

            traversal.Add(currentLevelValues);
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