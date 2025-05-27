// 771. Jewels and Stones
#region Вариант 1 - Runtime 0 ms, Beats 100.00%
public class Solution_771_1
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        var jewelCount = 0;

        foreach (var stone in stones)
        {
            if (jewels.Contains(stone))
            {
                jewelCount++;
            }
        }

        return jewelCount;
    }
}
#endregion

#region Вариант 2 - Runtime 0 ms, Beats 100.00%
public class Solution_771_2
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        var jewelCount = 0;

        var jewelsAsHashSet = new HashSet<char>(jewels);

        foreach (var stone in stones)
        {
            if (jewelsAsHashSet.Contains(stone))
            {
                jewelCount++;
            }
        }

        return jewelCount;
    }
}
#endregion