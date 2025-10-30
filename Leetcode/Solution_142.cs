// 142. Linked List Cycle II
public class Solution_142
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head?.next is null)
        {
            return null;
        }

        ListNode nodeInCycle = null;
        var fastPointer = head.next.next;
        var slowPointer = head.next;

        while (fastPointer?.next != null)
        {
            if (slowPointer == fastPointer)
            {
                nodeInCycle = slowPointer;
                break;
            }

            fastPointer = fastPointer.next?.next;
            slowPointer = slowPointer.next;
        }

        if (nodeInCycle is null)
        {
            return null;
        }

        var nodeFromHead = head;
        var nodeFromNodeInCycle = nodeInCycle;

        while (nodeFromHead != nodeFromNodeInCycle)
        {
            while (nodeFromNodeInCycle != nodeInCycle)
            {
                nodeFromNodeInCycle = nodeFromNodeInCycle.next;

                if (nodeFromHead == nodeFromNodeInCycle)
                {
                    return nodeFromHead;
                }
            }

            nodeFromHead = nodeFromHead.next;
            nodeFromNodeInCycle = nodeInCycle.next;
        }

        return nodeFromHead;
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