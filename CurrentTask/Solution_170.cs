// 170. Two Sum III - Data structure design

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */

public class TwoSum_170
{
    private readonly Dictionary<int, int> _numberToCountPairs;

    public TwoSum_170()
    {
        _numberToCountPairs = new Dictionary<int, int>();
    }

    public void Add(int number)
    {
        if (!_numberToCountPairs.ContainsKey(number))
        {
            _numberToCountPairs.Add(number, 0);
        }

        _numberToCountPairs[number]++;
    }

    public bool Find(int value)
    {
        foreach (var numberToCountPair in _numberToCountPairs)
        {
            var complement = value - numberToCountPair.Key;

            if (numberToCountPair.Key == complement)
            {
                if (numberToCountPair.Value >= 2)
                {
                    return true;
                }
            }
            else if (_numberToCountPairs.ContainsKey(complement))
            {
                return true;
            }
        }

        return false;
    }
}