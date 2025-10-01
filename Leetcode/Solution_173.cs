// 173. Binary Search Tree Iterator
public class BSTIterator_173
{
    private readonly Queue<int> _queue = new ();

    public BSTIterator_173(TreeNode root)
    {
        FillQueue(root);
    }

    private void FillQueue(TreeNode node)
    {
        if (node is null)
        {
            return;
        }

        if (node.left is not null)
        {
            FillQueue(node.left);
        }

        _queue.Enqueue(node.val);

        FillQueue(node.right);
    }

    public int Next()
    {
        return _queue.Dequeue();
    }

    public bool HasNext()
    {
        return _queue.Count > 0;
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
