// 27. Remove Element
public class Solution_27
{
    public int RemoveElement(int[] nums, int val)
    {
        var otherNumberIndex = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                (nums[i], nums[otherNumberIndex]) = (nums[otherNumberIndex], nums[i]);
                otherNumberIndex++;
            }
        }

        return otherNumberIndex;
    }
}