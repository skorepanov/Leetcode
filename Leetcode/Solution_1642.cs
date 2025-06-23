// 1642. Furthest Building You Can Reach

#region Solution 1 - Time Limit Exceeded
public class Solution_1642_1
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        if (heights.Length == 1)
        {
            return 0;
        }

        var jumpHeights = new int[heights.Length];

        for (var i = 1; i < heights.Length; i++)
        {
            if (heights[i - 1] < heights[i])
            {
                jumpHeights[i] = heights[i] - heights[i - 1];
            }
        }

        var nonZeroJumpHeights = jumpHeights.Where(h => h != 0).ToArray();

        var furthestBuilding = heights.Length - 1;

        while (furthestBuilding > 0)
        {
            var jumpHeightsForBricks = nonZeroJumpHeights
                .Take(furthestBuilding + 1)
                .OrderByDescending(h => h)
                .Skip(ladders)
                .ToArray();

            var bricksLeft = bricks;

            foreach (var jumpHeight in jumpHeightsForBricks)
            {
                bricksLeft -= jumpHeight;

                if (bricksLeft < 0)
                {
                    break;
                }
            }

            if (bricksLeft >= 0)
            {
                return furthestBuilding;
            }

            furthestBuilding--;
        }

        return furthestBuilding;
    }
}
#endregion

#region Solution 2 - Runtime 43 ms, Beats 30%
public class Solution_1642_2
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        var highestJumps = new PriorityQueue<int, int>();

        for (var i = 1; i < heights.Length; i++)
        {
            var currentJumpHeight = heights[i] - heights[i - 1];

            if (currentJumpHeight <= 0)
            {
                continue;
            }

            highestJumps.Enqueue(currentJumpHeight, currentJumpHeight);

            if (highestJumps.Count <= ladders)
            {
                continue;
            }

            var requiredBricks = highestJumps.Dequeue();
            bricks -= requiredBricks;

            if (bricks < 0)
            {
                return i - 1;
            }
        }

        return heights.Length - 1;
    }
}
#endregion
