// 24. Swap Nodes in Pairs
public class Solution_24
{
    public ListNode SwapPairs(ListNode head)
    {
        if (head?.next is null)
        {
            return head;
        }

        var secondNode = head.next;
        head.next = SwapPairs(secondNode.next);
        secondNode.next = head;

        return secondNode;
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