// 283. Move Zeroes
public class Solution_283
{
    public void MoveZeroes(int[] nums)
    {
        var zeroIndex = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0 && zeroIndex == -1)
            {
                zeroIndex = i;
            }
            else if (nums[i] != 0 && zeroIndex > -1)
            {
                (nums[i], nums[zeroIndex]) = (nums[zeroIndex], nums[i]);
                zeroIndex++;
            }
        }
    }
}