public class Solution_2
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var prehead = new ListNode(0);
        var currentNode = prehead;
        var hasOverflow = false;

        while (l1 != null || l2 != null || hasOverflow)
        {
            var sum = (l1?.val ?? 0) + (l2?.val ?? 0);

            if (hasOverflow)
            {
                sum++;
                hasOverflow = false;
            }

            if (sum >= 10)
            {
                sum -= 10;
                hasOverflow = true;
            }

            var sumNode = new ListNode(sum);
            currentNode.next = sumNode;
            currentNode = currentNode.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return prehead.next;
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