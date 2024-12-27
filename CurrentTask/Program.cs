using CurrentTask;

public class Solution1
{
    public static void Main()
    {
        var solution = new Solution();

        #region Solution 54
        //  int[][] array1 =
        //  {
        //      new [] { 1, 2, 3 },
        //      new [] { 4, 5, 6 },
        //      new [] { 7, 8, 9 }
        //  };
        // var result1 = solution.FindDiagonalOrder(array1);
        //
        //  int[][] array2 =
        //  {
        //      new [] { 1, 2 },
        //      new [] { 3, 4 }
        //  };
        // var result2 = solution.FindDiagonalOrder(array2);
        //
        // int[][] array3 = { new[] { 2, 3 } };
        // var result3 = solution.FindDiagonalOrder(array3);
        //
        // int[][] array4 = { new[] { 3 } , new [] { 2 } };
        // var result4 = solution.FindDiagonalOrder(array4);
        //
        // int[][] array5 = { new[] { 6, 9, 7 } };
        // var result5 = solution.FindDiagonalOrder(array5);
        #endregion

        #region Solution 54
        // int[][] array1 =
        // {
        //     new [] { 1, 2, 3 },
        //     new [] { 4, 5, 6 },
        //     new [] { 7, 8, 9 }
        // };
        // var result1 = solution.SpiralOrder(array1);


        // // [[1,2,3,4], [5,6,7,8], [9,10,11,12], [13,14,15,16], [17,18,19,20], [21,22,23,24]]
        // int[][] array2 =
        // {
        //     new [] { 1, 2, 3, 4 },
        //     new [] { 5, 6, 7, 8 },
        //     new [] { 9, 10, 11, 12 },
        //     new [] { 13, 14, 15, 16 },
        //     new [] { 17, 18, 19, 20 },
        //     new [] { 21, 22, 23, 24 }
        // };
        // // required output: [1,2,3,4,8,12,16,20,24,23,22,21,17,13,9,5,6,7,11,15,19,18,14,10]
        // var result2 = solution.SpiralOrder(array2);
        #endregion

        #region Solution 118
        var result = solution.Generate(5);
        #endregion
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