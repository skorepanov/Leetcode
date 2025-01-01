// 876. Middle of the Linked List
#region Вариант решения 1: перебор элементов с сохранением элементов списка в массиве
// public class Solution
// {
//     public ListNode MiddleNode(ListNode head)
//     {
//         var valuesAsList = new List<ListNode>();
//         var currentNode = head;
//
//         while (currentNode != null)
//         {
//             valuesAsList.Add(currentNode);
//             currentNode = currentNode.next;
//         }
//
//         var middleNodeIndex = valuesAsList.Count / 2;
//         return valuesAsList[middleNodeIndex];
//     }
// }
#endregion

// вариант решения 2: два указателя
public class Solution_876
{
    public ListNode MiddleNode(ListNode head)
    {
        var middleNode = head;
        var currentNode = head;
        var totalNodeCount = 1;

        while (currentNode != null)
        {
            totalNodeCount++;
            currentNode = currentNode.next;

            // перемещать middleNode имеет смысл только один раз на две итерации
            if (totalNodeCount % 2 == 1)
            {
                middleNode = middleNode.next;
            }
        }

        // или так
        // while (currentNode?.next != null)
        // {
        //     currentNode = currentNode.next.next;
        //     middleNode = middleNode.next;
        // }

        return middleNode;
    }

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val=0, ListNode next=null)
        {
            this.val = val;
            this.next = next;
        }
    }
}