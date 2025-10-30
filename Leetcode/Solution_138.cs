// 138. Copy List with Random Pointer
public class Solution_138
{
    public Node CopyRandomList(Node head)
    {
        if (head is null)
        {
            return null;
        }

        var visitedNodes = new Dictionary<Node, Node>();

        var currentOriginalNode = head;

        var pseudoHead = new Node(0);
        var currentNewNode = pseudoHead;

        // создать список с заполненными полями next
        do
        {
            var newNode = new Node(currentOriginalNode.val);
            currentNewNode.next = newNode;
            currentNewNode = currentNewNode.next;

            visitedNodes.Add(currentOriginalNode, currentNewNode);

            currentOriginalNode = currentOriginalNode.next;
        }
        while (currentOriginalNode != null);

        // заполнить поля random
        foreach (var visitedNodePair in visitedNodes)
        {
            if (visitedNodePair.Key.random != null)
            {
                visitedNodePair.Value.random = visitedNodes[visitedNodePair.Key.random];
            }
        }

        return pseudoHead.next;
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}