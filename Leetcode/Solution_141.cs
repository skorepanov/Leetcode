// 141. Linked List Cycle
public class Solution_141
{
    public bool HasCycle(ListNode head)
    {
        if (head?.next is null)
        {
            return false;
        }

        var fastPointer = head.next.next;
        var slowPointer = head.next;

        while (fastPointer?.next != null)
        {
            if (slowPointer == fastPointer)
            {
                return true;
            }

            fastPointer = fastPointer.next?.next;
            slowPointer = slowPointer.next;
        }

        return false;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next=null)
        {
            this.val = val;
            this.next = next;
        }
    }
}