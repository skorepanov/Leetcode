// 1584. Min Cost to Connect All Points

#region Вариант 1 - Kruskal’s Algorithm - Runtime 1055 ms, Beats 31.25%
public class Solution_1584_1
{
    public int MinCostConnectPoints(int[][] points)
    {
        var distances = GetDistances(points);

        var sortedDistances = distances
            .OrderBy(d => d.MathDistance)
            .ToList();

        var addedEdgeCount = 0;
        var distanceSum = 0m;
        var pointGroups = new List<HashSet<Point>>();

        foreach (var distance in sortedDistances)
        {
            if (addedEdgeCount == points.Length - 1)
            {
                break;
            }

            // если обе точки в одной группе - не добавлять точки
            var areBothPointsInSingleGroup = pointGroups
                .Any(g => g.Contains(distance.Point1) && g.Contains(distance.Point2));

            if (areBothPointsInSingleGroup)
            {
                continue;
            }

            var groupForPoint1 = pointGroups
                .FirstOrDefault(g => g.Contains(distance.Point1));
            var groupForPoint2 = pointGroups
                .FirstOrDefault(g => g.Contains(distance.Point2));

            // если обе точки не добавлены - создать новую группу точек
            if (groupForPoint1 is null && groupForPoint2 is null)
            {
                var newGroup = new HashSet<Point>
                {
                    distance.Point1,
                    distance.Point2
                };

                pointGroups.Add(newGroup);
            }
            // если у первой точки есть группа, а у второй нет -
            // добавить вторую точку в первую группу
            else if (groupForPoint1 is not null && groupForPoint2 is null)
            {
                groupForPoint1.Add(distance.Point2);
            }
            // если у второй точки есть группа, а у первой нет -
            // добавить первую точку во вторую группу
            else if (groupForPoint1 is null && groupForPoint2 is not null)
            {
                groupForPoint2.Add(distance.Point1);
            }
            else
            {
                // если обе точки в разных группах -
                // объединить группы
                var groupToRemove = groupForPoint1.Count > groupForPoint2.Count
                    ? groupForPoint2
                    : groupForPoint1;

                var groupToPersist = groupForPoint1.Count > groupForPoint2.Count
                    ? groupForPoint1
                    : groupForPoint2;

                pointGroups.Remove(groupToRemove);

                foreach (var point in groupToRemove)
                {
                    groupToPersist.Add(point);
                }
            }

            addedEdgeCount++;
            distanceSum += distance.MathDistance;
        }

        return (int)distanceSum;
    }

    private List<Distance> GetDistances(int[][] points)
    {
        var distances = new List<Distance>();

        for (var i = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var point1 = new Point(points[i][0], points[i][1]);
                var point2 = new Point(points[j][0], points[j][1]);

                var mathDistance = Math.Abs(point1.X - point2.X)
                                 + Math.Abs(point1.Y - point2.Y);

                var distance = new Distance(point1, point2, mathDistance);

                distances.Add(distance);
            }
        }

        return distances;
    }

    private record Point(int X, int Y);

    private record Distance(Point Point1, Point Point2, decimal MathDistance);
}
#endregion

#region Вариант 2 - Prim’s Algorithm - Runtime 2377 ms, Beats 5.56%
public class Solution_1584_2
{
    public int MinCostConnectPoints(int[][] points)
    {
        if (points.Length == 1)
        {
            return 0;
        }

        var distances = GetDistances(points);
        var distanceSum = 0m;

        var firstPoint = distances.Keys.First();

        var visitedPoints = new Dictionary<Point, PriorityQueue<Distance, decimal>>();
        visitedPoints.Add(firstPoint, distances[firstPoint]);

        while (visitedPoints.Count < points.Length)
        {
            var distance = visitedPoints
                .Select(p => p.Value.Peek())
                .OrderBy(d => d.MathDistance)
                .First();

            visitedPoints[distance.Point1].Dequeue();

            if (visitedPoints.ContainsKey(distance.Point2))
            {
                continue;
            }

            distanceSum += distance.MathDistance;
            visitedPoints.Add(distance.Point2, distances[distance.Point2]);
        }

        return (int)distanceSum;
    }

    private Dictionary<Point, PriorityQueue<Distance, decimal>>
        GetDistances(int[][] points)
    {
        var distances = new Dictionary<Point, PriorityQueue<Distance, decimal>>();

        for (var i = 0; i < points.Length; i++)
        {
            var point1 = new Point(points[i][0], points[i][1]);
            distances.Add(point1, new PriorityQueue<Distance, decimal>());

            for (var j = 0; j < points.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var point2 = new Point(points[j][0], points[j][1]);

                var mathDistance = Math.Abs(point1.X - point2.X)
                                 + Math.Abs(point1.Y - point2.Y);

                var distance = new Distance(point1, point2, mathDistance);

                distances[point1].Enqueue(distance, distance.MathDistance);
            }
        }

        return distances;
    }

    private record Point(int X, int Y);

    private record Distance(Point Point1, Point Point2, decimal MathDistance);
}
#endregion
