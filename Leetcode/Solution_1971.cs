// 1971. Find if Path Exists in Graph
public class Solution_1971
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
        {
            return true;
        }

        if (edges.Length == 0)
        {
            return false;
        }

        var visitedNodes = new bool[n];
        visitedNodes[source] = true;

        var connections = GetConnections(edges);

        return FindPath(source, visitedNodes, destination, connections);
    }

    private Dictionary<int, HashSet<int>> GetConnections(int[][] edges)
    {
        var connections = new Dictionary<int, HashSet<int>>();

        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];

            if (!connections.ContainsKey(from))
            {
                connections.Add(from, []);
            }

            connections[from].Add(to);

            if (!connections.ContainsKey(to))
            {
                connections.Add(to, []);
            }

            connections[to].Add(from);
        }

        return connections;
    }

    private bool FindPath(
        int currentNode,
        bool[] visitedNodes,
        int destination,
        Dictionary<int, HashSet<int>> connections)
    {
        if (currentNode == destination)
        {
            return true;
        }

        var adjacentNodes = connections[currentNode];

        foreach (var adjacentNode in adjacentNodes)
        {
            if (visitedNodes[adjacentNode])
            {
                continue;
            }

            visitedNodes[adjacentNode] = true;

            var isPathFounded = FindPath(adjacentNode, visitedNodes, destination, connections);

            if (isPathFounded)
            {
                return true;
            }
        }

        return false;
    }
}