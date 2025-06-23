// 1167. Minimum Cost to Connect Sticks
public class Solution_1167
{
    public int ConnectSticks(int[] sticks)
    {
        var orderedSticks = new PriorityQueue<int, int>();

        foreach (var stick in sticks)
        {
            orderedSticks.Enqueue(stick, stick);
        }

        var cost = 0;

        while (orderedSticks.Count > 1)
        {
            var stick1 = orderedSticks.Dequeue();
            var stick2 = orderedSticks.Dequeue();

            var diff = stick1 + stick2;
            cost += diff;

            orderedSticks.Enqueue(diff, diff);
        }

        return cost;
    }
}