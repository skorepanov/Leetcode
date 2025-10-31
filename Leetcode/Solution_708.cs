// 708. Insert into a Sorted Circular Linked List
public class Solution_708
{
    public Node Insert(Node head, int insertVal)
    {
        var newNode = new Node(insertVal);

        if (head is null)
        {
            head = newNode;
            head.next = head;
            return head;
        }

        var currentNode = head;

        do
        {
            // если значение между значениями узлов
            if (currentNode.val <= newNode.val && newNode.val <= currentNode.next.val
                // ИЛИ если значение больше максимального значения узлов
                || currentNode.val < newNode.val && currentNode.val > currentNode.next.val)
            {
                newNode.next = currentNode.next;
                currentNode.next = newNode;
                return head;
            }

            // если значение меньше минимального значения узлов
            if (newNode.val < currentNode.next.val && currentNode.val > currentNode.next.val)
            {
                newNode.next = currentNode.next;
                currentNode.next = newNode;
                return head;
            }

            currentNode = currentNode.next;
        }
        while (currentNode != head);

        newNode.next = head.next;
        head.next = newNode;

        return head;
    }

    public class Node
    {
        public int val;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
            next = null;
        }

        public Node(int _val, Node _next) {
            val = _val;
            next = _next;
        }
    }
}
