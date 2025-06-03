// 133. Clone Graph

// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution_133
{
    public Node CloneGraph(Node node)
    {
        if (node is null)
        {
            return null;
        }

        var newRootNode = new Node(node.val);

        var pendingOrigNodes = new Stack<Node>();
        pendingOrigNodes.Push(node);

        var origNodeToNewNode = new Dictionary<Node, Node>();
        origNodeToNewNode.Add(node, newRootNode);

        while (pendingOrigNodes.Count > 0)
        {
            var origNode = pendingOrigNodes.Pop();
            var newNode = origNodeToNewNode[origNode];

            foreach (var origNodeNeighbor in origNode.neighbors)
            {
                Node newNodeNeighbor;

                if (origNodeToNewNode.ContainsKey(origNodeNeighbor))
                {
                    newNodeNeighbor = origNodeToNewNode[origNodeNeighbor];
                    newNode.neighbors.Add(newNodeNeighbor);
                    continue;
                }

                newNodeNeighbor = new Node(origNodeNeighbor.val);
                newNode.neighbors.Add(newNodeNeighbor);

                origNodeToNewNode.Add(origNodeNeighbor, newNodeNeighbor);

                pendingOrigNodes.Push(origNodeNeighbor);
            }
        }

        return newRootNode;
    }
}