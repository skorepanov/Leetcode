// 75. Sort Colors
namespace CurrentTask;

public class Solution_75
{
    public void SortColors(int[] nums)
    {
        #region С помощью сортировки выбором
        // for (var i = 0; i < nums.Length; i++)
        // {
        //     var smallestIndex = i;
        //
        //     for (var j = i + 1; j < nums.Length; j++)
        //     {
        //         if (nums[j] < nums[smallestIndex])
        //         {
        //             smallestIndex = j;
        //         }
        //     }
        //
        //     if (smallestIndex != i)
        //     {
        //         (nums[i], nums[smallestIndex]) = (nums[smallestIndex], nums[i]);
        //     }
        // }
        #endregion

        #region One-pass algorithm
        var left = 0;
        var right = nums.Length - 1;
        var current = 0;

        while (current <= right)
        {
            if (nums[current] == 0)
            {
                (nums[left], nums[current]) = (nums[current], nums[left]);
                left++;
                current++;
            }
            else if (nums[current] == 2)
            {
                (nums[right], nums[current]) = (nums[current], nums[right]);
                right--;
            }
            else
            {
                current++;
            }
        }
        #endregion
    }
}
