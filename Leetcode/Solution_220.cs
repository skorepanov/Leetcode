// 220. Contains Duplicate III
public class Solution_220
{
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        var sortedNumbers = new SortedSet<int>();
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            var number = nums[right];

            var lowerValue = number - valueDiff;
            var upperValue = number + valueDiff;

            var view = sortedNumbers.GetViewBetween(lowerValue, upperValue);

            if (view.Count > 0)
            {
                return true;
            }

            sortedNumbers.Add(number);

            if (right - left >= indexDiff)
            {
                sortedNumbers.Remove(nums[left]);
                left++;
            }
        }

        return false;
    }
}