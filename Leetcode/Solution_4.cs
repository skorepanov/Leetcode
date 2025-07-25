// 4. Median of Two Sorted Arrays
public class Solution_4
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length == 0)
        {
            if (nums2.Length == 0)
            {
                return 0;
            }

            return GetMedian(nums2);
        }

        if (nums2.Length == 0)
        {
            return GetMedian(nums1);
        }

        var mergedNums = nums1
            .Concat(nums2)
            .Order()
            .ToArray();

        return GetMedian(mergedNums);
    }

    private double GetMedian(int[] nums)
    {
        return nums.Length % 2 == 1
            ? nums[nums.Length / 2]
            : (nums[nums.Length / 2 - 1] + nums[nums.Length / 2]) / 2.0;
    }
}
