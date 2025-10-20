// 912. Sort an Array

#region Вариант 1 - Heap sort - Runtime 79 ms, Beats 76.02%
public class Solution_912_1
{
    public int[] SortArray(int[] nums)
    {
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
#endregion

#region Вариант 2 - Merge sort - Runtime 133 ms, Beats 32.12%
public class Solution_912_2
{
    public int[] SortArray(int[] nums)
    {
        MergeSort(nums);
        return nums;
    }

    private void MergeSort(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return;
        }

        var middle = nums.Length / 2;

        var left = new int[middle];
        var right = new int[nums.Length - middle];

        for (var i = 0; i < middle; i++)
        {
            left[i] = nums[i];
        }

        for (var i = middle; i < nums.Length; i++)
        {
            right[i - middle] = nums[i];
        }

        MergeSort(left);
        MergeSort(right);

        Merge(nums, left, right);
    }

    private void Merge(int[] nums, int[] left, int[] right)
    {
        var numIndex = 0;
        var leftIndex = 0;
        var rightIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            nums[numIndex++] = left[leftIndex] < right[rightIndex]
                ? left[leftIndex++]
                : right[rightIndex++];
        }

        while (leftIndex < left.Length)
        {
            nums[numIndex++] = left[leftIndex++];
        }

        while (rightIndex < right.Length)
        {
            nums[numIndex++] = right[rightIndex++];
        }
    }
}
#endregion
