// 703. Kth Largest Element in a Stream

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

#region Вариант 1 - Priority Queue - Runtime 24 ms, Beats 84.97%
public class KthLargest_703_1
{
    private readonly PriorityQueue<int, int> _nums;
    private readonly int _k;

    public KthLargest_703_1(int k, int[] nums)
    {
        _nums = new PriorityQueue<int, int>();
        _k = k;

        foreach (var num in nums)
        {
            _nums.Enqueue(num, num);

            if (_nums.Count > _k)
            {
                _nums.Dequeue();
            }
        }
    }

    public int Add(int val)
    {
        if (_nums.Count < _k || _nums.Peek() < val)
        {
            _nums.Enqueue(val, val);

            if (_nums.Count > _k)
            {
                _nums.Dequeue();
            }
        }

        return _nums.Peek();
    }
}
#endregion

#region Вариант 2 - Binary Search Tree - Runtime 757 ms, Beats 5.19%
public class KthLargest_703_2
{
    private TreeNode _root;
    private readonly int _k;

    public KthLargest_703_2(int k, int[] nums)
    {
        _k = k;

        foreach (var num in nums)
        {
            InsertNum(num);
        }
    }

    public int Add(int val)
    {
        InsertNum(val);

        var kthLargest = GetKthLargest(_root, _k);
        return kthLargest;
    }

    private void InsertNum(int num)
    {
        if (_root is null)
        {
            _root = new TreeNode(num);
            return;
        }

        var node = _root;

        while (node is not null)
        {
            if (node.val < num)
            {
                node.countRight++;

                if (node.right is null)
                {
                    node.right = new TreeNode(num);
                    return;
                }

                node = node.right;
            }
            else
            {
                if (node.left is null)
                {
                    node.left = new TreeNode(num);
                    return;
                }

                node = node.left;
            }
        }
    }

    private int GetKthLargest(TreeNode node, int k)
    {
        if (k <= node.countRight)
        {
            return GetKthLargest(node.right, k);
        }

        if (k - node.countRight == 1)
        {
            return node.val;
        }

        k = k - node.countRight - 1;

        return GetKthLargest(node.left, k);
    }

    private class TreeNode
    {
        public int val;
        public int countRight;
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
