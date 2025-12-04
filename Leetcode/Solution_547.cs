// 547. Number of Provinces
public class Solution_547
{
    public int FindCircleNum(int[][] isConnected)
    {
        if (isConnected is null || isConnected.Length == 0)
        {
            return 0;
        }

        var disjointSet = new DisjointSet(isConnected);
        return disjointSet.Count;
    }

    private class DisjointSet
    {
        private readonly Dictionary<int, int> _root = new ();
        private readonly Dictionary<int, int> _rank = new ();

        public int Count { get; private set; }

        public DisjointSet(int[][] isConnected)
        {
            FillRootAndRank(isConnected);
            UnionNums(isConnected);
        }

        private void FillRootAndRank(int[][] isConnected)
        {
            for (var i = 0; i < isConnected.Length; i++)
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

        private void UnionNums(int[][] isConnected)
        {
            Count = _root.Count;

            for (var i = 0; i < isConnected.Length; i++)
            {
                for (var j = i + 1; j < isConnected.Length; j++)
                {
                    if (isConnected[i][j] == 1 && FindRoot(i) != FindRoot(j))
                    {
                        Union(i, j);
                        Count--;
                    }
                }
            }
        }

        private void Union(int x, int y)
        {
            var rootX = FindRoot(x);
            var rootY = FindRoot(y);

            if (rootX == rootY)
            {
                return;
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
        }
    }
}