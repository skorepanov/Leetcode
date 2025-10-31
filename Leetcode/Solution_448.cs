// 448. Find All Numbers Disappeared in an Array
public class Solution_448
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var nonExistentNums = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            nonExistentNums.Add(i + 1);
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nonExistentNums.Contains(nums[i]))
            {
                nonExistentNums.Remove(nums[i]);
            }
        }

        return nonExistentNums.ToList();
    }
}