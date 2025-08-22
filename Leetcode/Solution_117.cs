// 117. Populating Next Right Pointers in Each Node II

#region Runtime 87 ms, Beats 57.63%
public class Solution_117_1
{
    public Node Connect(Node root)
    {
        if (root is null)
        {
            return null;
        }

        var pendingNodes = new Queue<Node>();
        pendingNodes.Enqueue(root);

        while (pendingNodes.Count > 0)
        {
            var nodeCount = pendingNodes.Count;

            for (var i = 1; i <= nodeCount; i++)
            {
                var node = pendingNodes.Dequeue();

                if (i < nodeCount)
                {
                    node.next = pendingNodes.Peek();
                }

                if (node.left is not null)
                {
                    pendingNodes.Enqueue(node.left);
                }

                if (node.right is not null)
                {
                    pendingNodes.Enqueue(node.right);
                }
            }
        }

        return root;
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
#endregion

#region Runtime 81ms, Beats 80.51%
public class Solution_117_2
{
    /// <summary>
    /// Предыдущий узел на текущем уровне
    /// </summary>
    private Node _previousNode;

    /// <summary>
    /// Самый левый элемент на текущем уровне
    /// </summary>
    private Node _leftmost;

    public Node Connect(Node root)
    {
        if (root is null)
        {
            return null;
        }

        this._leftmost = root;
        Node currentLevelNode;

        while (this._leftmost is not null)
        {
            // одна итерация - один уровень дерева
            this._previousNode = null;
            currentLevelNode = this._leftmost;
            this._leftmost = null;

            while (currentLevelNode is not null)
            {
                ProcessChild(currentLevelNode.left);
                ProcessChild(currentLevelNode.right);
                currentLevelNode = currentLevelNode.next;
            }
        }

        return root;
    }

    private void ProcessChild(Node childNode)
    {
        if (childNode is null)
        {
            return;
        }

        if (this._previousNode is not null)
        {
            this._previousNode.next = childNode;
        }
        else
        {
            this._leftmost = childNode;
        }

        this._previousNode = childNode;
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
#endregion
