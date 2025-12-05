// 1168. Optimize Water Distribution in a Village
public class Solution_1168
{
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
    {
        var edges = new List<HouseCost>(n + 1 + pipes.Length);

        // add the virtual vertex (index with 0) along with the new edges.
        for (var i = 0; i < wells.Length; i++)
        {
            var houseCost = new HouseCost(House1: 0, House2: i + 1, Cost: wells[i]);
            edges.Add(houseCost);
        }

        // add the existing edges
        foreach (var pipe in pipes)
        {
            var houseCost = new HouseCost(House1: pipe[0], House2: pipe[1], Cost: pipe[2]);
            edges.Add(houseCost);
        }

        edges.Sort((edge1, edge2) => edge1.Cost - edge2.Cost);

        var disjointSet = new DisjointSet(n);
        var totalCost = 0;

        foreach (var edge in edges)
        {
            // determine if we should add the new edge to the final MST
            if (disjointSet.TryUnion(edge.House1, edge.House2))
            {
                totalCost += edge.Cost;
            }
        }

        return totalCost;
    }

    private class DisjointSet
    {
        private readonly int[] _group;
        private readonly int[] _rank;

        public DisjointSet(int size)
        {
            // the index of member starts from 1
            _group = new int[size + 1];
            _rank = new int[size + 1];

            for (var i = 0; i < size + 1; i++)
            {
                _group[i] = i;
                _rank[i] = 1;
            }
        }

        public bool TryUnion(int house1, int house2)
        {
            var group1 = FindGroup(house1);
            var group2 = FindGroup(house2);

            if (group1 == group2)
            {
                return false;
            }

            if (_rank[group1] > _rank[group2])
            {
                _group[group2] = group1;
            }
            else if (_rank[group1] < _rank[group2])
            {
                _group[group1] = group2;
            }
            else
            {
                _group[group1] = group2;
                _rank[group2]++;
            }

            return true;
        }

        private int FindGroup(int house)
        {
            if (_group[house] != house)
            {
                _group[house] = FindGroup(_group[house]);
            }

            return _group[house];
        }
    }

    private record HouseCost(int House1, int House2, int Cost);
}