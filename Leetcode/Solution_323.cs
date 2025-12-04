// 323. Number of Connected Components in an Undirected Graph
public class Solution_323
{
    private readonly Dictionary<int, int> _root = new ();
    private readonly Dictionary<int, int> _rank = new ();

    public int CountComponents(int n, int[][] edges)
    {
        var disjointSet = new DisjointSet(n, edges);
        return disjointSet.Count;
    }

    private class DisjointSet
    {
        private readonly Dictionary<int, int> _root = new();
        private readonly Dictionary<int, int> _rank = new();

        public int Count { get; private set; }

        public DisjointSet(int edgeCount, int[][] edges)
        {
            FillRootAndRank(edgeCount);
            UnionEdges(edges);
        }

        private void FillRootAndRank(int edgeCount)
        {
            for (var i = 0; i < edgeCount; i++)
            {
                _root.Add(i, i);
                _rank.Add(i, 1);
            }
        }

        private int FindRoot(int x)
        {
            if (x == _root[x])
            {
                return x;
            }

            _root[x] = FindRoot(_root[x]);

            return _root[x];
        }

        private void UnionEdges(int[][] edges)
        {
            Count = _root.Count;

            foreach (var edge in edges)
            {
                if (TryUnion(edge[0], edge[1]))
                {
                    Count--;
                }
            }
        }

        private bool TryUnion(int x, int y)
        {
            var rootX = FindRoot(x);
            var rootY = FindRoot(y);

            if (rootX == rootY)
            {
                return false;
            }

            if (_rank[rootX] > _rank[rootY])
            {
                _root[rootY] = rootX;
            }
            else if (_rank[rootX] < _rank[rootY])
            {
                _root[rootX] = rootY;
            }
            else
            {
                _root[rootY] = rootX;
                _rank[rootX]++;
            }

            return true;
        }
    }
}