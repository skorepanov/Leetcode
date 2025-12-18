// 746. Min Cost Climbing Stairs
public class Solution_746
{
    private readonly Dictionary<int, int> _cache = new ();

    public int MinCostClimbingStairs(int[] cost)
    {
        return MinCostClimbingStairs(cost, step: cost.Length);
    }

    private int MinCostClimbingStairs(int[] cost, int step)
    {
        if (step <= 1)
        {
            return 0;
        }

        if (_cache.TryGetValue(step, out var value))
        {
            return value;
        }

        var costForStepMinus1 = MinCostClimbingStairs(cost, step - 1) + cost[step - 1];
        var costForStepMinus2 = MinCostClimbingStairs(cost, step - 2) + cost[step - 2];

        var min = Math.Min(costForStepMinus1, costForStepMinus2);

        _cache.Add(step, min);

        return min;
    }
}