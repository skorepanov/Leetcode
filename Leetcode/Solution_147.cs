// 147. Insertion Sort List
public class Solution_147
{
    public ListNode InsertionSortList(ListNode head)
    {
        var pseudoHead = new ListNode(0, head);
        var current1 = pseudoHead;

        while (current1.next != null)
        {
            var current2 = pseudoHead;

            while (current1.next != current2.next && current2.next.val < current1.next.val)
            {
                current2 = current2.next;
            }

            if (current1.next != current2.next)
            {
                var swap1 = current1.next;
                current1.next = current1.next.next;

                var swap2 = current2.next;
                current2.next = swap1;
                current2.next.next = swap2;
            }
            else
            {
                current1 = current1.next;
            }
        }

        return pseudoHead.next;
    }
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
