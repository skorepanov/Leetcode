// 215. Kth Largest Element in an Array
namespace CurrentTask;

public class Solution_215
{
    public int FindKthLargest(int[] nums, int k) {
        #region With sorting
        // var sortedNums = nums.OrderByDescending(n => n).ToArray();
        // return sortedNums[k - 1];
        #endregion

        #region Without sorting, with PriorityQueue
        var heap = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            heap.Enqueue(num, num);

            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        return heap.Peek();
        #endregion
    }
}