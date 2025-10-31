// 203. Remove Linked List Elements
public class Solution_203
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head is null)
        {
            return null;
        }

        var previousNode = head;
        var currentNode = head.next;

        while (currentNode != null)
        {
            if (currentNode.val == val)
            {
                previousNode.next = currentNode.next;
                currentNode = currentNode.next;
            }
            else
            {
                previousNode = currentNode;
                currentNode = currentNode.next;
            }
        }

        if (head.val == val)
        {
            return head.next;
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