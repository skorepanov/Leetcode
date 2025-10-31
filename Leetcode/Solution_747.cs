// 747. Largest Number At Least Twice of Others
public class Solution_747
{
    public int DominantIndex(int[] nums)
    {
        var indexOfLargest = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > nums[indexOfLargest])
            {
                indexOfLargest = i;
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (i != indexOfLargest && nums[i] * 2 > nums[indexOfLargest])
            {
                return -1;
            }
        }

        return indexOfLargest;
    }
}
