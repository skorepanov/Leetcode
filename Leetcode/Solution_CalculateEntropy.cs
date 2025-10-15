// Calculate Entropy
public class Solution_CalculateEntropy
{
    public double CalculateEntropy(int[] input)
    {
        var probabilities = new Dictionary<int, double>();

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