using CurrentTask;

public class Solution1
{
    public static void Main()
    {
        var solution = new Solution();

         int[][] array1 =
         {
             new [] { 1, 2, 3 },
             new [] { 4, 5, 6 },
             new [] { 7, 8, 9 }
         };
        var result1 = solution.FindDiagonalOrder(array1);

         int[][] array2 =
         {
             new [] { 1, 2 },
             new [] { 3, 4 }
         };
        var result2 = solution.FindDiagonalOrder(array2);

        int[][] array3 = { new[] { 2, 3 } };
        var result3 = solution.FindDiagonalOrder(array3);

        int[][] array4 = { new[] { 3 } , new [] { 2 } };
        var result4 = solution.FindDiagonalOrder(array4);

        int[][] array5 = { new[] { 6, 9, 7 } };
        var result5 = solution.FindDiagonalOrder(array5);
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}