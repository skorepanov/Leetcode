// 328. Odd Even Linked List
public class Solution_328
{
    public ListNode OddEvenList(ListNode head)
    {
        if (head?.next is null)
        {
            return head;
        }

        // нечётный
        var odd = head;

        // чётный
        var even = head.next;
        var evenHead = even;

        while (even != null && even.next != null)
        {
            odd.next = even.next;
            odd = odd.next;

            even.next = odd.next;
            even = even.next;
        }

        odd.next = evenHead;

        return head;
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