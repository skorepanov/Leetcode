// 787. Cheapest Flights Within K Stops
public class Solution_787
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        if (src == dst)
        {
            return 0;
        }

        var previous = new int[n];
        var current = new int[n];

        for (var i = 0; i < n; i++)
        {
            previous[i] = int.MaxValue;
            current[i] = int.MaxValue;
        }

        previous[src] = 0;

        for (var i = 1; i < k + 2; i++)
        {
            current[src] = 0;

            foreach (var flight in flights)
            {
                var nodeFrom = flight[0];
                var nodeTo = flight[1];
                var cost = flight[2];

                if (previous[nodeFrom] < int.MaxValue)
                {
                    current[nodeTo] = Math.Min(
                        current[nodeTo],
                        previous[nodeFrom] + cost);
                }
            }

            previous = current.Clone() as int[];
        }

        return current[dst] == int.MaxValue ? -1 : current[dst];
    }
}