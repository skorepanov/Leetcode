// 3217. Delete Nodes From Linked List Present in Array
public class Solution_3217
{
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        var numsToDelete = new HashSet<int>(nums);

        var pseudoHead = new ListNode(val: 0, next: head);
        var currentNode = pseudoHead;

        while (currentNode.next is not null)
        {
            if (numsToDelete.Contains(currentNode.next.val))
            {
                currentNode.next = currentNode.next.next;
            }
            else
            {
                currentNode = currentNode.next;
            }
        }

        return pseudoHead.next;
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