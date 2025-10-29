#region 2 вариант - С помощью битовых операций - Runtime 0 ms, Beats 100.00%

public class Solution_137_2
{
    public int SingleNumber(int[] nums)
    {
        var seenOnce = 0;
        var seenTwice = 0;

        foreach (var num in nums)
        {
            // (seenOnce ⊕ num) & ~seenTwice
            // т.е. прибавить новое число, убрать число, встречавшееся 2 раза
            seenOnce = (seenOnce ^ num) & (~seenTwice);

            // (seenTwice ⊕ num) & ~seenTwice
            // т.е. прибавить новое число, убрать число, встречавшееся 1 раз
            seenTwice = (seenTwice ^ num) & (~seenOnce);
        }

        return seenOnce;
    }
}
#endregion

#region 1 вариант - С помощью Dictionary - Runtime 4 ms, Beats 27.00%
public class Solution_137_1
{
    public int SingleNumber(int[] nums)
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

        return counts.First(c => c.Value == 1).Key;
    }
}
#endregion
