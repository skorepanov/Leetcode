// 977. Squares of a Sorted Array
public class Solution_977
{
    public int[] SortedSquares(int[] nums)
    {
        var numsLength = nums.Length;
        var sortedNums = new int[numsLength];
        var left = 0;
        var right = numsLength - 1;

        for (var i = numsLength - 1; i >= 0; i--)
        {
            if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
            {
                sortedNums[i] = nums[left] * nums[left];
                left++;
            }
            else
            {
                sortedNums[i] = nums[right] * nums[right];
                right--;
            }
        }

        return sortedNums;
    }
}