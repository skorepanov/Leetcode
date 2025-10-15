// Calculate Maximum Information Gain
public class Solution_CalculateMaximumInformationGain
{
    public double CalculateMaxInfoGain(double[] petal_length, string[] species)
    {
        if (petal_length.Length == 0)
        {
            return 0;
        }

        var combined = petal_length
            .Zip(species, (length, spec) => new { Length = length, Spec = spec })
            .OrderBy(t => t.Length)
            .ToList();

        var sortedSpecies = combined.Select(t => t.Spec).ToArray();

        var minEntropyOfGroups = double.MaxValue;

        for (var i = 1; i <= sortedSpecies.Length - 1; i++)
        {
            var firstGroup = sortedSpecies.Take(i).ToArray();
            var firstGroupEntropy = CalculateEntropy(firstGroup);

            var secondGroup = sortedSpecies.Skip(i).ToArray();
            var secondGroupEntropy = CalculateEntropy(secondGroup);

            var entropyOfGroups =
                firstGroupEntropy * firstGroup.Length / sortedSpecies.Length
              + secondGroupEntropy * secondGroup.Length / sortedSpecies.Length;

            minEntropyOfGroups = Math.Min(minEntropyOfGroups, entropyOfGroups);
        }

        var overallEntropy = CalculateEntropy(sortedSpecies);
        var maxInfoGain = overallEntropy - minEntropyOfGroups;

        return maxInfoGain;
    }

    private double CalculateEntropy(string[] input)
    {
        var probabilities = new Dictionary<string, double>();

        foreach (var val in input)
        {
            if (probabilities.ContainsKey(val))
            {
                continue;
            }

            var count = input.Count(v => v == val);
            var probability = (double)count / input.Length;
            probabilities.Add(val, probability);
        }

        var entropy = 0d;

        foreach (var probability in probabilities)
        {
            entropy -= probability.Value * Math.Log2(probability.Value);
        }

        return entropy;
    }
}