// 310. Minimum Height Trees
public class Solution_310
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n < 2)
        {
            return Enumerable.Range(start: 0, count: n).ToList();
        }

        var graph = GetGraph(edges);

        var leaves = graph
            .Where(g => g.Value.Count == 1)
            .Select(g => g.Key)
            .ToList();

        var remainingNodeCount = n;

        while (remainingNodeCount > 2)
        {
            remainingNodeCount -= leaves.Count;
            var newLeaves = new List<int>();

            foreach (var leaf in leaves)
            {
                var nextNode = graph[leaf].First();
                graph[nextNode].Remove(leaf);

                if (graph[nextNode].Count == 1)
                {
                    newLeaves.Add(nextNode);
                }
            }

            leaves = newLeaves;
        }

        return leaves;
    }

    private Dictionary<int, HashSet<int>> GetGraph(int[][] edges)
    {
        var graph = new Dictionary<int, HashSet<int>>();

        foreach (var edge in edges)
        {
            var node1 = edge[0];
            var node2 = edge[1];

            if (!graph.ContainsKey(node1))
            {
                graph.Add(node1, []);
            }

            graph[node1].Add(node2);

            if (!graph.ContainsKey(node2))
            {
                graph.Add(node2, []);
            }

            graph[node2].Add(node1);
        }

        return graph;
    }
}