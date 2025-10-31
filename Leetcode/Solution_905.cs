// 905. Sort Array By Parity
public class Solution_905
{
    public int[] SortArrayByParity(int[] nums)
    {
        var evenIndex = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                (nums[i], nums[evenIndex]) = (nums[evenIndex], nums[i]);
                evenIndex++;
            }
        }

        return nums;
    }
}