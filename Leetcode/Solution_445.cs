// 445. Add Two Numbers II
public class Solution_445
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var stack1 = new Stack<ListNode>();

        var node = l1;

        while (node != null)
        {
            stack1.Push(node);
            node = node.next;
        }

        var stack2 = new Stack<ListNode>();

        node = l2;

        while (node != null)
        {
            stack2.Push(node);
            node = node.next;
        }

        var prehead = new ListNode();
        node = prehead;
        var carry = 0;

        while (stack1.Count > 0 || stack2.Count > 0)
        {
            var val1 = stack1.Count > 0 ? stack1.Pop().val : 0;
            var val2 = stack2.Count > 0 ? stack2.Pop().val : 0;

            var sum = (val1 + val2 + carry) % 10;
            carry = (val1 + val2 + carry) / 10;

            var newNode = new ListNode(sum, node.next);
            node.next = newNode;
        }

        if (carry > 0)
        {
            var newNode = new ListNode(carry, node.next);
            node.next = newNode;
        }

        return prehead.next;
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