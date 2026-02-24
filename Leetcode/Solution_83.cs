// 83. Remove Duplicates from Sorted List
public class Solution_83
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head is null || head.next is null)
        {
            return head;
        }

        var currentNode = head;

        while (currentNode.next is not null)
        {
            if (currentNode.val == currentNode.next.val)
            {
                currentNode.next = currentNode.next.next;
                continue;
            }

            currentNode = currentNode.next;
        }

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