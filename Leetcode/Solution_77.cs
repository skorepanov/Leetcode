// 77. Combinations
public class Solution_77
{
    private int _n;
    private int _k;

    public IList<IList<int>> Combine(int n, int k)
    {
        _n = n;
        _k = k;

        var currentNumberCombinations = new List<int>();
        var allCombinations = new List<IList<int>>();
        Combine(currentNumber: 1, ref currentNumberCombinations, allCombinations);
        return allCombinations;
    }

    private void Combine(
        int currentNumber,
        ref List<int> currentNumberCombinations,
        List<IList<int>> allCombinations)
    {
        if (currentNumberCombinations.Count == _k)
        {
            allCombinations.Add(currentNumberCombinations);
            currentNumberCombinations = currentNumberCombinations.ToList();
            return;
        }

        for (var i = currentNumber; i <= _n; i++)
        {
            currentNumberCombinations.Add(i);

            Combine(currentNumber: i + 1, ref currentNumberCombinations, allCombinations);

            currentNumberCombinations.Remove(i);
        }
    }
}