// 160. Intersection of Two Linked Lists
public class Solution_160
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var pointerA = headA;
        var pointerB = headB;

        var nodesOfB = new HashSet<ListNode>();

        while (pointerB != null)
        {
            nodesOfB.Add(pointerB);
            pointerB = pointerB.next;
        }

        while (pointerA != null)
        {
            if (nodesOfB.Contains(pointerA))
            {
                return pointerA;
            }

            pointerA = pointerA.next;
        }

        return null;
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