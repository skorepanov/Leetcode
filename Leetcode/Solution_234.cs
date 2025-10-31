// 234. Palindrome Linked List
public class Solution_234
{
    public bool IsPalindrome(ListNode head)
    {
        if (head?.next is null)
        {
            return true;
        }

        var nodesAsStack = new Stack<int>();
        var currentNode = head;

        while (currentNode != null)
        {
            nodesAsStack.Push(currentNode.val);
            currentNode = currentNode.next;
        }

        currentNode = head;

        while (currentNode != null)
        {
            var rightValue = nodesAsStack.Pop();

            if (currentNode.val != rightValue)
            {
                return false;
            }

            currentNode = currentNode.next;
        }

        return true;
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