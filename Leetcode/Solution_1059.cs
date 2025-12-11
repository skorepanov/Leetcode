// 1059. All Paths from Source Lead to Destination
public class Solution_1059
{
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination)
    {
        var connections = GetConnections(n, edges);
        return LeadsToDestination(source, destination, connections, states: new Color?[n]);
    }

    private Dictionary<int, HashSet<int>> GetConnections(int n, int[][] edges)
    {
        var connections = new Dictionary<int, HashSet<int>>();

        for (var i = 0; i < n; i++)
        {
            connections.Add(i, []);
        }

        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];

            connections[from].Add(to);
        }

        return connections;
    }

    private bool LeadsToDestination(
        int node,
        int destination,
        Dictionary<int, HashSet<int>> connections,
        Color?[] states)
    {
        // If the state is GRAY, this is a backward edge and hence, it creates a loop.
        if (states[node] is not null)
        {
            return states[node] == Color.Black;
        }

        // If this is a leaf node, it should be equal to the destination.
        if (connections[node].Count == 0)
        {
            return node == destination;
        }

        // Now, we are processing this node. So we mark it as GRAY
        states[node] = Color.Gray;

        var adjacentNodes = connections[node];

        foreach (var adjacentNode in adjacentNodes)
        {
            // If we get a `false` from any recursive call on the neighbors,
            // we short circuit and return from there.
            var isLeads = LeadsToDestination(
                adjacentNode, destination, connections, states);

            if (!isLeads)
            {
                return false;
            }
        }

        // Recursive processing done for the node. We mark it BLACK
        states[node] = Color.Black;
        return true;
    }

    // We don't use the state WHITE as such anywhere.
    // Instead, the "null" value in the states array below is a substitute for WHITE.
    private enum Color
    {
        Gray,
        Black
    }
}