// 743. Network Delay Time
public class Solution_743
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var connections = GetConnections(times);

        var timeByNode = Enumerable
            .Range(1, n)
            .ToDictionary(v => v, _ => (int?)null);
        timeByNode[k] = 0;

        var pendingNodes = new Queue<int>();
        pendingNodes.Enqueue(k);

        while (pendingNodes.Count > 0)
        {
            var nodeCount = pendingNodes.Count;

            for (var i = 0; i < nodeCount; i++)
            {
                var currentNode = pendingNodes.Dequeue();
                var weightToCurrentNode = timeByNode[currentNode].Value;

                if (!connections.ContainsKey(currentNode))
                {
                    continue;
                }

                var nodeConnections = connections[currentNode];

                foreach (var connection in nodeConnections)
                {
                    var adjacentNode = connection.Item1;
                    var adjacentNodeWeight = connection.Item2;

                    var weightToAdjacentNode = weightToCurrentNode + adjacentNodeWeight;

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