// 206. Reverse Linked List

#region Вариант 1 - Итеративно - Runtime 0 ms, Beats 100.00%
public class Solution_206_1
{
    public ListNode ReverseList(ListNode head)
    {
        if (head?.next is null)
        {
            return head;
        }

        var currentNode = head;

        while (currentNode.next != null)
        {
            var nextNode = currentNode.next;
            currentNode.next = nextNode.next;

            nextNode.next = head;
            head = nextNode;
        }

        return head;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
#endregion

#region Вариант 2 - Рекурсивно - Runtime 0 ms, Beats 100.00%
public class Solution_206_2
{
    public ListNode ReverseList(ListNode head)
    {
        if (head?.next is null)
        {
            return head;
        }

        var node = ReverseList(head.next);

        head.next.next = head;
        head.next = null;

        return node;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
#endregion
