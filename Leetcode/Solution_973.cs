// 973. K Closest Points to Origin
public class Solution_973
{
    public int[][] KClosest(int[][] points, int k)
    {
        var comparer = Comparer<double>.Create((x, y) => y.CompareTo(x));

        var closestPoints = new PriorityQueue<Point, double>(comparer);

        foreach (var pointCoordinates in points)
        {
            var point = new Point(pointCoordinates[0], pointCoordinates[1]);

            // формула дистанции до точки (0, 0): sqrt(X^2+Y^2),
            // но sqrt() здесь можно не рассчитывать
            var distance = Math.Pow(point.X, 2) + Math.Pow(point.Y, 2);

            closestPoints.Enqueue(point, distance);

            if (closestPoints.Count > k)
            {
                closestPoints.Dequeue();
            }
        }

        var closestPointCoordinates = new int[closestPoints.Count][];
        var i = 0;

        while (closestPoints.Count > 0)
        {
            var point = closestPoints.Dequeue();

            closestPointCoordinates[i] =
            [
                point.X,
                point.Y
            ];

            i++;
        }

        return closestPointCoordinates;
    }

    private record Point(int X, int Y);
}