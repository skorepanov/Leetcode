// 797. All Paths From Source to Target
public class Solution_797
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var paths = new List<IList<int>>();
        var currentPath = new List<int> { 0 };

        FindPaths(
            currentNode: 0, destination: graph.Length - 1,
            graph, currentPath, paths);

        return paths;
    }

    private void FindPaths(
        int currentNode,
        int destination,
        int[][] graph,
        List<int> currentPath,
        IList<IList<int>> paths)
    {
        if (currentNode == destination)
        {
            paths.Add(currentPath.ToList());
            return;
        }

        var adjacentNodes = graph[currentNode];

        foreach (var adjacentNode in adjacentNodes)
        {
            currentPath.Add(adjacentNode);

            FindPaths(adjacentNode, destination, graph, currentPath, paths);

            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}