// 19. Remove Nth Node From End of List
public class Solution_19
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var nodesAsList = new List<ListNode>();

        var pointer = head;

        while (pointer != null)
        {
            nodesAsList.Add(pointer);
            pointer = pointer.next;
        }

        if (nodesAsList.Count == n)
        {
            return head.next;
        }

        var previousNode = nodesAsList[nodesAsList.Count - n - 1];

        previousNode.next = previousNode.next.next;

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