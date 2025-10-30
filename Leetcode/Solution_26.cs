// 26. Remove Duplicates from Sorted Array
public class Solution_26
{
    public int RemoveDuplicates(int[] nums)
    {
        var nonDuplicatesIndex = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[nonDuplicatesIndex] = nums[i];
                nonDuplicatesIndex++;
            }
        }

        return nonDuplicatesIndex;
    }
}