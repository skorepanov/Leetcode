// 61. Rotate List
public class Solution_61
{
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head?.next is null || k <= 0)
        {
            return head;
        }

        var nodeCount = 1;
        var oldTail = head;

        do
        {
            nodeCount++;
            oldTail = oldTail.next;
        }
        while (oldTail.next != null);

        oldTail.next = head;
        var newTail = head;
        var correctedK = k % nodeCount;

        for (var i = 0; i < nodeCount - correctedK - 1; i++)
        {
            newTail = newTail.next;
        }

        var newHead = newTail.next;
        newTail.next = null;

        return newHead;
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