// 912. Sort an Array
namespace CurrentTask;

public class Solution_912
{
    public int[] SortArray(int[] nums)
    {
        // using heap sort
        for (var i = nums.Length / 2 - 1; i >= 0; i--)
        {
            maxHeapify(nums, nums.Length, i);
        }

        for (var i = nums.Length - 1; i > 0; i--)
        {
            (nums[i], nums[0]) = (nums[0], nums[i]);
            maxHeapify(nums, i, 0);
        }

        return nums;
    }

    void maxHeapify(int[] nums, int heapSize, int index)
    {
        var left = 2 * index + 1;
        var right = 2 * index + 2;
        var largest = index;

        if (left < heapSize && nums[left] > nums[largest])
        {
            largest = left;
        }

        if (right < heapSize && nums[right] > nums[largest])
        {
            largest = right;
        }

        if (largest != index)
        {
            (nums[index], nums[largest]) = (nums[largest], nums[index]);
            maxHeapify(nums, heapSize, largest);
        }
    }
}