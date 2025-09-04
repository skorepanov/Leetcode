// 21. Merge Two Sorted Lists

#region Вариант 1 - Итеративно - Runtime 0 ms, Beats 100.00%
public class Solution_21_1
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var pseudoHead = new ListNode(0);
        var currentMergeListNode = pseudoHead;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                currentMergeListNode.next = list1;
                currentMergeListNode = currentMergeListNode.next;
                list1 = list1.next;
            }
            else
            {
                currentMergeListNode.next = list2;
                currentMergeListNode = currentMergeListNode.next;
                list2 = list2.next;
            }
        }

        currentMergeListNode.next = list1 ?? list2;

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
#endregion

#region Вариант 2 - Рекурсивно - Runtime 0 ms, Beats 100.00%
public class Solution_21_2
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 is null)
        {
            return list2;
        }

        if (list2 is null)
        {
            return list1;
        }

        if (list1.val < list2.val)
        {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }

        list2.next = MergeTwoLists(list1, list2.next);
        return list2;
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
#endregion
