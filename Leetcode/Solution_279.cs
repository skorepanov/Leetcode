// 279. Perfect Squares
public class Solution_279
{
    public int NumSquares(int n)
    {
        var perfectSquares = GetPerfectSquares(n);

        if (perfectSquares.Last() == n)
        {
            return 1;
        }

        var counter = 2;
        var pendingRemains = new Queue<int>();

        foreach (var perfectSquare in perfectSquares)
        {
            pendingRemains.Enqueue(n - perfectSquare);
        }

        var pendedRemains = new HashSet<int>();

        while (pendingRemains.Count > 0)
        {
            var size = pendingRemains.Count;

            for (var i = 0; i < size; i++)
            {
                var remain = pendingRemains.Dequeue();

                var squares = perfectSquares
                    .Where(s => s <= remain)
                    .ToArray();

                foreach (var square in squares)
                {
                    var nextRemain = remain - square;

                    if (nextRemain == 0)
                    {
                        return counter;
                    }

                    if (pendedRemains.Contains(nextRemain))
                    {
                        continue;
                    }

                    pendingRemains.Enqueue(nextRemain);
                    pendedRemains.Add(nextRemain);
                }
            }

            counter++;
        }

        return counter;
    }

    private int[] GetPerfectSquares(int maxSquare)
    {
        var squares = new List<int>();
        var current = 1;

        while (current * current <= maxSquare)
        {
            squares.Add(current * current);
            current++;
        }

        return squares.ToArray();
    }
}