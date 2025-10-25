// 426. Convert Binary Search Tree to Sorted Doubly Linked List

#region Вариант 1 - С помощью обхода in order - Runtime 75 ms, Beats 45.16%
public class Solution_426_1
{
    public Node TreeToDoublyList(Node root)
    {
        if (root is null)
        {
            return null;
        }

        var visited = new List<Node>();
        TraverseInOrder(root, visited);

        for (var i = 0; i < visited.Count - 1; i++)
        {
            var firstNode = visited[i];
            var secondNode = visited[i + 1];

            firstNode.right = secondNode;
            secondNode.left = firstNode;
        }

        var minNode = visited.First();
        var maxNode = visited.Last();

        maxNode.right = minNode;
        minNode.left = maxNode;

        return minNode;
    }

    private void TraverseInOrder(Node node, List<Node> visited)
    {
        if (node is null)
        {
            return;
        }

        TraverseInOrder(node.left, visited);
        visited.Add(node);
        TraverseInOrder(node.right, visited);
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node(int val = 0, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
#endregion

#region Вариант 2 - Без предварительного обхода дерева - Runtime 65 ms, Beats 88.71%
public class Solution_426_2
{
    private Node _firstNode = null;
    private Node _lastNode = null;

    public Node TreeToDoublyList(Node root)
    {
        if (root is null)
        {
            return null;
        }

        ConvertToDoublyList(root);

        _lastNode.right = _firstNode;
        _firstNode.left = _lastNode;

        return _firstNode;
    }

    private void ConvertToDoublyList(Node node)
    {
        if (node is null)
        {
            return;
        }

        // left
        ConvertToDoublyList(node.left);

        // node
        if (_lastNode is not null)
        {
            _lastNode.right = node;
            node.left = _lastNode;
        }
        else
        {
            _firstNode = node;
        }

        _lastNode = node;

        // right
        ConvertToDoublyList(node.right);
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node(int val = 0, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
#endregion
