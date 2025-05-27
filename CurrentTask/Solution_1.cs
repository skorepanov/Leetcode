// 1. Two Sum
#region Вариант 1 - Runtime 7 ms, Beats 53.50%
public class Solution_1_1
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, List<int>>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                dict[nums[i]].Add(i);
            }
            else
            {
                dict.Add(nums[i], [i]);
            }
        }

        foreach (var keyValue in dict)
        {
            var firstNum = keyValue.Key;
            var secondNum = target - firstNum;

            if (firstNum == secondNum)
            {
                if (keyValue.Value.Count > 1)
                {
                    return [keyValue.Value[0], keyValue.Value[1]];
                }
            }
            else
            {
                if (dict.ContainsKey(secondNum))
                {
                    return [keyValue.Value[0], dict[secondNum][0]];
                }
            }
        }

        return [];
    }
}
#endregion

#region Вариант 2 - Runtime 6 ms, Beats 53.76%
public class Solution_1_2
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, List<int>>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (dict.ContainsKey(num))
            {
                if (target - num == num)
                {
                    return [dict[num][0], i];
                }

                dict[num].Add(i);
            }
            else
            {
                dict.Add(num, [i]);
            }
        }

        foreach (var keyValue in dict)
        {
            var firstNum = keyValue.Key;
            var secondNum = target - firstNum;

            if (firstNum == secondNum)
            {
                if (keyValue.Value.Count > 1)
                {
                    return [keyValue.Value[0], keyValue.Value[1]];
                }
            }
            else
            {
                if (dict.ContainsKey(secondNum))
                {
                    return [keyValue.Value[0], dict[secondNum][0]];
                }
            }
        }

        return [];
    }
}
#endregion

#region Вариант 3 - Runtime 1 ms, Beats 98.29%
public class Solution_1_3
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var complement = target - num;

            if (dict.ContainsKey(complement))
            {
                return [dict[complement], i];
            }

            dict[num] = i;
        }

        return [];
    }
}
#endregion