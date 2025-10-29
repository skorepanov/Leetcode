// 260. Single Number III

#region 2 вариант - С помощью битовых операций - Runtime 0 ms, Beats 100.00%
public class Solution_260_2
{
    public int[] SingleNumber(int[] nums)
    {
        // разница между x и y, которые встретились ровно один раз
        var bitmask = 0;

        foreach (var num in nums)
        {
            bitmask ^= num;
        }

        // крайняя правая разница в 1 бит между x и y
        var diff = bitmask & (-bitmask);

        var x = 0;

        // битовая маска, которая будет содержать только x
        foreach (var num in nums)
        {
            if ((num & diff) != 0)
            {
                x ^= num;
            }
        }

        var y = bitmask ^ x;

        return [x, y];
    }
}
#endregion

#region 1 вариант - С помощью Dictionary - Runtime 8 ms, Beats 16.26%
public class Solution_260_1
{
    public int[] SingleNumber(int[] nums)
    {
        var counts = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!counts.ContainsKey(num))
            {
                counts.Add(num, 1);
            }
            else
            {
                counts[num]++;
            }
        }

        return counts
            .Where(c => c.Value == 1)
            .Select(c => c.Key)
            .ToArray();
    }
}
#endregion
