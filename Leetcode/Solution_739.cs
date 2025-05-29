// 739. Daily Temperatures
public class Solution_739
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var dayCounts = new int[temperatures.Length];
        var indexesOfDayCounts = new Stack<int>();

        for (var i = 0; i < temperatures.Length - 1; i++)
        {
            if (temperatures[i] >= temperatures[i + 1])
            {
                indexesOfDayCounts.Push(i);
                continue;
            }

            dayCounts[i] = 1;

            while (indexesOfDayCounts.Count > 0
                && temperatures[indexesOfDayCounts.Peek()] < temperatures[i + 1])
            {
                var indexOfDayCounts = indexesOfDayCounts.Pop();
                var dayCount = i + 1 - indexOfDayCounts;
                dayCounts[indexOfDayCounts] = dayCount;
            }
        }

        return dayCounts;
    }
}