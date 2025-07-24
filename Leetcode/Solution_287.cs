// 287. Find the Duplicate Number

#region Вариант 1 - С сортировкой - Runtime 117 ms, Beats 5.99%
public class Solution_287_1
{
    public int FindDuplicate(int[] nums)
    {
        var sortedNums = nums.Order().ToArray();

        for (var i = 1; i < sortedNums.Length; i++)
        {
            if (sortedNums[i] == sortedNums[i - 1])
            {
                return sortedNums[i];
            }
        }

        return -1;
    }
}
#endregion

#region Вариант 2 - HashSet - Runtime 31 ms, Beats 25.58%
public class Solution_287_2
{
    public int FindDuplicate(int[] nums)
    {
        var consideredNumbers = new HashSet<int>();

        foreach (var num in nums)
        {
            if (consideredNumbers.Contains(num))
            {
                return num;
            }

            consideredNumbers.Add(num);
        }

        return -1;
    }
}
#endregion

#region Вариант 3 - Binary Search - Runtime 35 ms, Beats 16.08%
public class Solution_287_3
{
    public int FindDuplicate(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;
        var duplicate = -1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            var count = nums.Count(n => n <= middle);

            if (count > middle)
            {
                duplicate = middle;
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return duplicate;
    }
}
#endregion
