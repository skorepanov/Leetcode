// 652. Find Duplicate Subtrees

#region Вариант 1 (мой) - Runtime 4285 ms, Beats 7.14%
public class Solution_652_1
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        var allSubtrees = GetSubtrees(root);

        var uniqueDuplicateRoots = new HashSet<TreeNode>();
        var allDuplicateRoots = new HashSet<TreeNode>();

        foreach (var node1 in allSubtrees)
        {
            if (allDuplicateRoots.Contains(node1))
            {
                continue;
            }

            foreach (var node2 in allSubtrees)
            {
                if (node1 == node2)
                {
                    continue;
                }

                if (IsEqualTrees(node1, node2))
                {
                    uniqueDuplicateRoots.Add(node1);
                    allDuplicateRoots.Add(node1);
                    allDuplicateRoots.Add(node2);
                }
            }
        }

        return uniqueDuplicateRoots.ToList();
    }

    private List<TreeNode> GetSubtrees(TreeNode root)
    {
        if (root is null)
        {
            return new List<TreeNode>();
        }

        var leftSubtrees = GetSubtrees(root.left);
        var rightSubtrees = GetSubtrees(root.right);

        var subtrees = new List<TreeNode>();
        subtrees.Add(root);
        subtrees.AddRange(leftSubtrees);
        subtrees.AddRange(rightSubtrees);

        return subtrees;
    }

    private bool IsEqualTrees(TreeNode node1, TreeNode node2)
    {
        if (node1 is null && node2 is null)
        {
            return true;
        }

        if (node1 is not null && node2 is not null)
        {
            return node1.val == node2.val
                && IsEqualTrees(node1.left, node2.left)
                && IsEqualTrees(node1.right, node2.right);
        }

        return false;
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

#region Вариант 2 (не мой) - Runtime 19 ms, Beats 42.86%
public class Solution_652_2
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        var duplicateSubtrees = new List<TreeNode>();
        var nodeRepresentationToCount = new Dictionary<string, int>();

        Traverse(root, nodeRepresentationToCount, duplicateSubtrees);

        return duplicateSubtrees;
    }

    public string Traverse(
        TreeNode node,
        Dictionary<string, int> nodeRepresentationToCount,
        List<TreeNode> res)
    {
        if (node is null)
        {
            return string.Empty;
        }

        var leftNodeRepresentation = Traverse(node.left, nodeRepresentationToCount, res);
        var rightNodeRepresentation = Traverse(node.right, nodeRepresentationToCount, res);

        var representation = $"({leftNodeRepresentation}){node.val}({rightNodeRepresentation})";

        if (nodeRepresentationToCount.ContainsKey(representation))
        {
            nodeRepresentationToCount[representation]++;
        }
        else
        {
            nodeRepresentationToCount.Add(representation, 1);
        }

        if (nodeRepresentationToCount[representation] == 2)
        {
            res.Add(node);
        }

        return representation;
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