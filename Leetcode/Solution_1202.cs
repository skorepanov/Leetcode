// 1202. Smallest String With Swaps
public class Solution_1202
{
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
    {
        var disjointSet = AddPairsToDisjointSet(s, pairs);
        var rootToComponent = GetRootToComponent(s, disjointSet);
        var smallestString = GetSmallestString(s, rootToComponent);

        return smallestString;
    }

    private DisjointSet AddPairsToDisjointSet(string s, IList<IList<int>> pairs)
    {
        var disjointSet = new DisjointSet(s.Length);

        foreach (var pair in pairs)
        {
            var firstIndex = pair[0];
            var secondIndex = pair[1];

            disjointSet.Union(firstIndex, secondIndex);
        }

        return disjointSet;
    }

    private Dictionary<int, List<int>> GetRootToComponent(string s, DisjointSet disjointSet)
    {
        var rootToComponent = new Dictionary<int, List<int>>();

        for (var index = 0; index < s.Length; index++)
        {
            var root = disjointSet.FindRoot(index);

            if (!rootToComponent.ContainsKey(root))
            {
                rootToComponent.Add(root, []);
            }

            rootToComponent[root].Add(index);
        }

        return rootToComponent;
    }

    private string GetSmallestString(string s, Dictionary<int, List<int>> rootToComponent)
    {
        var smallestString = new char[s.Length];

        foreach (var indices in rootToComponent.Values)
        {
            var characters = indices
                .Select(index => s[index])
                .Order()
                .ToList();

            for (var index = 0; index < indices.Count; index++)
            {
                smallestString[indices[index]] = characters[index];
            }
        }

        return new string(smallestString);
    }

    private class DisjointSet
    {
        private readonly int[] _root;
        private readonly int[] _rank;

        public DisjointSet(int size)
        {
            _root = new int[size];
            _rank = new int[size];

            for (var i = 0; i < size; i++)
            {
                _root[i] = i;
                _rank[i] = 1;
            }
        }

        public int FindRoot(int x)
        {
            if (x == _root[x])
            {
                return x;
            }

            _root[x] = FindRoot(_root[x]);

            return _root[x];
        }

        public void Union(int x, int y)
        {
            var rootX = FindRoot(x);
            var rootY = FindRoot(y);

            if (rootX == rootY)
            {
                return;
            }

            if (_rank[rootX] >= _rank[rootY])
            {
                _root[rootY] = rootX;
                _rank[rootX] += _rank[rootY];
            }
            else
            {
                _root[rootX] = rootY;
                _rank[rootY] += _rank[rootX];
            }
        }
    }
}