// 1101. The Earliest Moment When Everyone Become Friends
public class Solution_1101
{
    public int EarliestAcq(int[][] logs, int n)
    {
        var disjointSet = new DisjointSet(n, logs);
        return disjointSet.MinTime ?? -1;
    }

    private class DisjointSet
    {
        private readonly Dictionary<int, int> _root = new();
        private readonly Dictionary<int, int> _rank = new();
        public int? MinTime { get; private set; }

        public DisjointSet(int edgeCount, int[][] edges)
        {
            var sortedEdges = edges.OrderBy(x => x[0]).ToArray();

            FillRootAndRank(edgeCount);
            UnionEdges(sortedEdges);
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
            var count = _root.Count;

            foreach (var edge in edges)
            {
                if (TryUnion(edge[1], edge[2]))
                {
                    count--;

                    if (count == 1)
                    {
                        MinTime = edge[0];
                        return;
                    }
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