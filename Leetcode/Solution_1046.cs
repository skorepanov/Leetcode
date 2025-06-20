// 1046. Last Stone Weight
public class Solution_1046
{
    public int LastStoneWeight(int[] stones)
    {
        var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        var orderedStones = new PriorityQueue<int, int>(comparer);

        foreach (var stone in stones)
        {
            orderedStones.Enqueue(stone, stone);
        }

        while (orderedStones.Count > 1)
        {
            var x = orderedStones.Dequeue();
            var y = orderedStones.Dequeue();

            if (x != y)
            {
                var diff = x - y;
                orderedStones.Enqueue(diff, diff);
            }
        }

        return orderedStones.Count > 0
            ? orderedStones.Dequeue()
            : 0;
    }
}