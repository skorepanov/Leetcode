// 1232. Check If It Is a Straight Line
public class Solution_1232
{
    public bool CheckStraightLine(int[][] coordinates)
    {
        if (coordinates.Length == 2)
        {
            return true;
        }

        var deltaX = GetDeltaX(coordinates[0], coordinates[1]);
        var deltaY = GetDeltaY(coordinates[0], coordinates[1]);

        for (var i = 2; i < coordinates.Length; i++)
        {
            if (deltaY * GetDeltaX(coordinates[0], coordinates[i])
             != deltaX * GetDeltaY(coordinates[0], coordinates[i]))
            {
                return false;
            }
        }

        return true;
    }

    private int GetDeltaX(int[] point1, int[] point2)
        => point2[0] - point1[0];

    private int GetDeltaY(int[] point1, int[] point2)
        => point2[1] - point1[1];
}