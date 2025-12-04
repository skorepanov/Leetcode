// 261. Graph Valid Tree
public class Solution_261
{
    private readonly Dictionary<int, int> _root = new ();
    private readonly Dictionary<int, int> _rank = new ();

    public bool ValidTree(int n, int[][] edges)
    {
        var disjointSet = new DisjointSet(n, edges);
        return disjointSet.IsValidGraph;
    }

    private class DisjointSet
    {
        private readonly Dictionary<int, int> _root = new ();
        private readonly Dictionary<int, int> _rank = new ();
        private int _count;

        public bool IsValidGraph { get; }

        public DisjointSet(int edgeCount, int[][] edges)
        {
            FillRootAndRank(edgeCount);
            var areEdgesUnion = TryUnionEdges(edges);

            IsValidGraph = areEdgesUnion && _count == 1;
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

        private bool TryUnionEdges(int[][] edges)
        {
            _count = _root.Count;

            foreach (var edge in edges)
            {
                if (!TryUnion(edge[0], edge[1]))
                {
                    return false;
                }

                _count--;
            }

            return true;
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