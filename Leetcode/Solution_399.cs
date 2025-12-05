// 399. Evaluate Division
public class Solution_399
{
    public double[] CalcEquation(
        IList<IList<string>> equations,
        double[] values,
        IList<IList<string>> queries)
    {
        var gidWeight = BuildUnionGroups(equations, values);
        var results = EvaluateQueries(queries, gidWeight);
        return results;
    }

    private Dictionary<string, Pair> BuildUnionGroups(
        IList<IList<string>> equations,
        double[] values)
    {
        var gidWeight = new Dictionary<string, Pair>();

        for (var i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            var quotient = values[i];

            var dividend = equation[0];
            var divisor = equation[1];

            Union(gidWeight, dividend, divisor, quotient);
        }

        return gidWeight;
    }

    private double[] EvaluateQueries(
        IList<IList<string>> queries,
        Dictionary<string, Pair> gidWeight)
    {
        // run the evaluation, with "lazy" updates in Find() function
        var results = new double[queries.Count];

        for (var i = 0; i < queries.Count; i++)
        {
            var query = queries[i];

            var dividend = query[0];
            var divisor = query[1];

            if (!gidWeight.ContainsKey(dividend) || !gidWeight.ContainsKey(divisor))
            {
                results[i] = -1;
                continue;
            }

            var dividendPair = FindVariable(gidWeight, dividend);
            var divisorPair = FindVariable(gidWeight, divisor);

            var dividendGid = dividendPair.Key;
            var divisorGid = divisorPair.Key;

            if (dividendGid != divisorGid)
            {
                // the variables do not belong to the same chain/group
                results[i] = -1;
                continue;
            }

            // there is a chain/path between the variables
            var dividendWeight = dividendPair.Value;
            var divisorWeight = divisorPair.Value;

            results[i] = dividendWeight / divisorWeight;
        }

        return results;
    }

    private void Union(
        Dictionary<string, Pair> gidWeight,
        string dividend,
        string divisor,
        double value)
    {
        var dividendEntry = FindVariable(gidWeight, dividend);
        var divisorEntry = FindVariable(gidWeight, divisor);

        var dividendGid = dividendEntry.Key;
        var divisorGid = divisorEntry.Key;

        var dividendWeight = dividendEntry.Value;
        var divisorWeight = divisorEntry.Value;

        if (dividendGid != divisorGid)
        {
            // merge the two groups together,
            // by attaching the dividend group to the one of divisor
            var valueForDivisor = divisorWeight * value / dividendWeight;
            gidWeight[dividendGid] = new Pair(divisorGid, valueForDivisor);
        }
    }

    private Pair FindVariable(Dictionary<string, Pair> gidWeight, string nodeId)
    {
        if (!gidWeight.ContainsKey(nodeId))
        {
            var newPair = new Pair(nodeId, value: 1);
            gidWeight.Add(nodeId, newPair);
            return newPair;
        }

        var pair = gidWeight[nodeId];

        if (pair.Key != nodeId)
        {
            var newPair = FindVariable(gidWeight, pair.Key);
            gidWeight[nodeId] = new Pair(newPair.Key, pair.Value * newPair.Value);
        }

        return gidWeight[nodeId];
    }

    private class Pair
    {
        public string Key { get; set; }
        public double Value { get; set; }

        public Pair(string key, double value)
        {
            Key = key;
            Value = value;
        }
    }
}