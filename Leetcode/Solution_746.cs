// 746. Min Cost Climbing Stairs

#region Вариант 1 - Top-down - Space complexity O(n)
// Runtime 1 ms, Beats 43.98%
// Memory 44.55 MB, Beats 14.05%

public class Solution_746_1
{
    private readonly Dictionary<int, int> _cache = new ();

    public int MinCostClimbingStairs(int[] cost)
    {
        return Dp(cost, step: cost.Length);
    }

    private int Dp(int[] cost, int step)
    {
        if (step <= 1)
        {
            return 0;
        }

        if (_cache.TryGetValue(step, out var value))
        {
            return value;
        }

        var costForStepMinus1 = Dp(cost, step - 1) + cost[step - 1];
        var costForStepMinus2 = Dp(cost, step - 2) + cost[step - 2];

        var min = Math.Min(costForStepMinus1, costForStepMinus2);

        _cache.Add(step, min);

        return min;
    }
}
#endregion

#region Вариант 2 - Bottom-up - Space complexity O(n)
// Runtime 0 ms, Beats 100.00%
// Memory 43.47 MB, Beats 55.11%

public class Solution_746_2
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var cache = new int[cost.Length + 1];

        cache[0] = 0;
        cache[1] = 0;

        for (var i = 2; i < cost.Length + 1; i++)
        {
            var costForStepMinus1 = cache[i - 1] + cost[i - 1];
            var costForStepMinus2 = cache[i - 2] + cost[i - 2];

            cache[i] = Math.Min(costForStepMinus1, costForStepMinus2);
        }

        return cache[^1];
    }
}
#endregion

#region Вариант 3 - Bottom-up - Space complexity O(1)
// Runtime 0 ms, Beats 100.00%
// Memory 42.90 MB, Beats 97.81%

public class Solution_746_3
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var stepMinus2 = 0;
        var stepMinus1 = 0;
        var lastStep = 0;

        for (var i = 2; i < cost.Length + 1; i++)
        {
            stepMinus2 = stepMinus1;
            stepMinus1 = lastStep;

            var costForStepMinus1 = stepMinus1 + cost[i - 1];
            var costForStepMinus2 = stepMinus2 + cost[i - 2];

            lastStep = Math.Min(costForStepMinus1, costForStepMinus2);
        }

        return lastStep;
    }
}
#endregion
