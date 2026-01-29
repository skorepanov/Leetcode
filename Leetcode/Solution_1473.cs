// 1473. Paint House III
public class Solution_1473
{
    private int[] _houses;
    private int[][] _costs;
    private int _houseCount;
    private int _colorCount;
    private int _target;
    private int?[,,] _cache;

    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        _houses = houses;
        _costs = cost;
        _houseCount = m;
        _colorCount = cost[0].Length;
        _target = target;

        _cache = new int?[_houseCount + 1, _colorCount + 1, _target + 1];

        var dp = Dp(i: 0, prevColor: 0, neighborhoodCount: 0);

        return dp != int.MaxValue
            ? dp
            : -1;
    }

    private int Dp(int i, int prevColor, int neighborhoodCount)
    {
        if (i == _houseCount)
        {
            return neighborhoodCount == _target
                ? 0
                : int.MaxValue;
        }

        if (neighborhoodCount > _target)
        {
            return int.MaxValue;
        }

        if (_cache[i, prevColor, neighborhoodCount] is not null)
        {
            return _cache[i, prevColor, neighborhoodCount].Value;
        }

        var minCost = int.MaxValue;

        if (_houses[i] != 0)
        {
            var targetLeftForNext = prevColor == _houses[i]
                ? neighborhoodCount
                : neighborhoodCount + 1;

            minCost = Dp(i + 1, prevColor: _houses[i], targetLeftForNext);
        }
        else
        {
            for (var currentColor = 1; currentColor <= _colorCount; currentColor++)
            {
                var targetLeftForNext = prevColor == currentColor
                    ? neighborhoodCount
                    : neighborhoodCount + 1;

                var dpNext = Dp(i + 1, currentColor, targetLeftForNext);

                if (dpNext == int.MaxValue)
                {
                    continue;
                }

                var currentCost = dpNext + _costs[i][currentColor - 1];
                minCost = Math.Min(minCost, currentCost);
            }
        }

        _cache[i, prevColor, neighborhoodCount] = minCost;

        return _cache[i, prevColor, neighborhoodCount].Value;
    }
}