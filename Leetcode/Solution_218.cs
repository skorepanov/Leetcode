// 218. The Skyline Problem
public class Solution_218
{
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        var positionsAsSet = new SortedSet<int>();

        foreach (var building in buildings)
        {
            positionsAsSet.Add(building[0]);
            positionsAsSet.Add(building[1]);
        }

        var positions = positionsAsSet.ToList();

        var skyline = new List<IList<int>>();

        foreach (var position in positions)
        {
            var maxHeight = 0;

            foreach (var building in buildings)
            {
                var left = building[0];
                var right = building[1];
                var height = building[2];

                if (left <= position && position < right)
                {
                    maxHeight = Math.Max(maxHeight, height);
                }
            }

            if (skyline.Count == 0 || skyline[^1][1] != maxHeight)
            {
                skyline.Add([position, maxHeight]);
            }
        }

        return skyline;
    }
}