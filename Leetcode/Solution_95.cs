// 95. Unique Binary Search Trees II
public class Solution_95
{
    public IList<TreeNode> GenerateTrees(int n)
    {
        if (n == 1)
        {
            return [new TreeNode(1)];
        }

        var prevTrees = GenerateTrees(n - 1);
        var trees = new List<TreeNode>();

        foreach (var prevTree in prevTrees)
        {
            // добавить дерево, где n добавлен последним
            var treeCopy1 = CopyTree(prevTree);
            AddNode(n, treeCopy1);
            trees.Add(treeCopy1);

            // добавить дерево, где n - корень
            var root = new TreeNode(n);
            var treeCopy2 = CopyTree(prevTree);
            root.left = treeCopy2;
            trees.Add(root);

            // добавить дерево, где n добавлен в середину
            var currNode = prevTree;

            while (currNode.right != null)
            {
                var treeCopy3 = CopyTree(prevTree);

                AddBefore(n, currNode.right.val, treeCopy3);
                trees.Add(treeCopy3);

                currNode = currNode.right;
            }
        }

        return trees;
    }

    private TreeNode CopyTree(TreeNode node)
    {
        if (node == null)
        {
            return null;
        }

        var nodeCopy = new TreeNode(node.val);
        nodeCopy.left = CopyTree(node.left);
        nodeCopy.right = CopyTree(node.right);

        return nodeCopy;
    }

    private void AddNode(int n, TreeNode node)
    {
        if (n < node.val)
        {
            if (node.left != null)
            {
                AddNode(n, node.left);
            }
            else
            {
                node.left = new TreeNode(n);
            }
        }
        else
        {
            if (node.right != null)
            {
                AddNode(n, node.right);
            }
            else
            {
                node.right = new TreeNode(n);
            }
        }
    }

    private void AddBefore(int n, int valueToInsertBefore, TreeNode node)
    {
        if (node.right.val != valueToInsertBefore)
        {
            AddBefore(n, valueToInsertBefore, node.right);
            return;
        }

        var newNode = new TreeNode(n);
        newNode.left = node.right;
        node.right = newNode;
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