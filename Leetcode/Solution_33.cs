// 33. Search in Rotated Sorted Array
public class Solution_33
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 1)
        {
            return nums[0] == target ? 0 : -1;
        }

        // 1. Найти сдвиг (индекс наименьшего элемента)
        var pivot = GetPivot(nums);

        // 2. Найти target с учётом сдвига
        return GetTarget(nums, target, pivot);
    }

    private int GetPivot(int[] nums)
    {
        var arrayLength = nums.Length;
        var left = 0;
        var right = arrayLength - 1;

        while (left <= right)
        {
            var middle = (left + right) / 2;

            if (nums[middle] > nums[arrayLength - 1])
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return left;
    }

    private int GetTarget(int[] nums, int target, int pivot)
    {
        var arrayLength = nums.Length;
        var left = 0;
        var right = arrayLength - 1;

        while (left <= right)
        {
            var middle = (left + right) / 2;
            var pivotedMiddle = (middle + pivot) % arrayLength;

            if (nums[pivotedMiddle] == target)
            {
                return pivotedMiddle;
            }

            if (nums[pivotedMiddle] > target)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return -1;
    }
}