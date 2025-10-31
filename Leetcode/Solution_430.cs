// 430. Flatten a Multilevel Doubly Linked List
public class Solution_430
{
    public Node Flatten(Node head)
    {
        var currentNode = head;

        while (currentNode != null)
        {
            if (currentNode.child is null)
            {
                currentNode = currentNode.next;
                continue;
            }

            var childNode = Flatten(currentNode.child);

            var currentChildNode = childNode;

            while (currentChildNode.next != null)
            {
                currentChildNode = currentChildNode.next;
            }

            if (currentNode.next != null)
            {
                currentChildNode.next = currentNode.next;
                currentNode.next.prev = currentChildNode;
            }

            childNode.prev = currentNode;
            currentNode.next = childNode;

            currentNode.child = null;
            currentNode = currentNode.next;
        }

        return head;
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }
}