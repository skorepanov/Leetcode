// 334. Increasing Triplet Subsequence
public class Solution_334
{
    private int[] _nums;

    public bool IncreasingTriplet(int[] nums)
    {
        _nums = nums;

        return IncreasingTriplet(left: 0, right: nums.Length - 1);
    }

    private bool IncreasingTriplet(int left, int right)
    {
        while (left < right - 1)
        {
            if (_nums[left] >= _nums[left + 1])
            {
                left++;
                continue;
            }

            if (_nums[right - 1] >= _nums[right])
            {
                right--;
                continue;
            }

            break;
        }

        if (left + 1 >= right)
        {
            return false;
        }

        var haveLower = false;
        var haveUpper = false;

        for (var j = left + 1; j <= right - 1; j++)
        {
            if (_nums[left] < _nums[j] && _nums[j] < _nums[right])
            {
                return true;
            }

            if (_nums[j] < _nums[left])
            {
                haveLower = true;
            }
            else if (_nums[j] > _nums[right])
            {
                haveUpper = true;
            }
        }

        if (!haveLower && !haveUpper)
        {
            return false;
        }

        return IncreasingTriplet(left + 1, right)
            || IncreasingTriplet(left, right - 1);
    }
}