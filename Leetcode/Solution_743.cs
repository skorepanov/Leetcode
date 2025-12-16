// 743. Network Delay Time
public class Solution_743
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var connections = GetConnections(times);

        var timeByNode = Enumerable
            .Range(1, n)
            .ToDictionary(v => v, _ => (int?)null);

        var pendingNodes = new Queue<int>();
        pendingNodes.Enqueue(k);
        timeByNode[k] = 0;

        while (pendingNodes.Count > 0)
        {
            var nodeCount = pendingNodes.Count;

            for (var i = 0; i < nodeCount; i++)
            {
                var node = pendingNodes.Dequeue();
                var weightToCurrentNode = timeByNode[node].Value;

                if (!connections.ContainsKey(node))
                {
                    continue;
                }

                var nodeConnections = connections[node];

                foreach (var connection in nodeConnections)
                {
                    var adjacentNode = connection.Item1;
                    var weight = connection.Item2;

                    var weightToAdjacentNode = weightToCurrentNode + weight;

                    if ((timeByNode[adjacentNode] ?? int.MaxValue) > weightToAdjacentNode)
                    {
                        timeByNode[adjacentNode] = weightToAdjacentNode;
                        pendingNodes.Enqueue(adjacentNode);
                    }
                }
            }
        }

        if (timeByNode.Values.Any(v => v is null))
        {
            return -1;
        }

        return timeByNode.Values.Max().Value;
    }

    private Dictionary<int, List<(int, int)>> GetConnections(int[][] times)
    {
        var connections = new Dictionary<int, List<(int, int)>>();

        foreach (var time in times)
        {
            var nodeFrom = time[0];
            var nodeTo = time[1];
            var weight = time[2];

            if (!connections.ContainsKey(nodeFrom))
            {
                connections.Add(nodeFrom, []);
            }

            connections[nodeFrom].Add((nodeTo, weight));
        }

        return connections;
    }
}