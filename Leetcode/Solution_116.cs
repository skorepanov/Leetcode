// 116. Populating Next Right Pointers in Each Node

#region Вариант 1 - Runtime 90 ms, Beats 52.88%
public class Solution_116_1
{
    public Node Connect(Node root)
    {
        if (root is null)
        {
            return null;
        }

        if (root.left is not null)
        {
            root.left.next = root.right;
            Connect(root.left);
            ConnectLeftToRight(root.left, root.right);
        }

        if (root.right is not null)
        {
            Connect(root.right);
        }

        return root;
    }

    private void ConnectLeftToRight(Node left, Node right)
    {
        if (left.right is not null)
        {
            left.right.next = right.left;
            ConnectLeftToRight(left.right, right.left);
        }
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

#region Вариант 2 - Runtime 96 ms, Beats 29.15%
public class Solution_116_2
{
    public Node Connect(Node root)
    {
        if (root is null)
        {
            return null;
        }

        if (root.left is not null)
        {
            root.left.next = root.right;
        }

        if (root.right is not null && root.next is not null)
        {
            root.right.next = root.next.left;
        }

        Connect(root.left);
        Connect(root.right);

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
