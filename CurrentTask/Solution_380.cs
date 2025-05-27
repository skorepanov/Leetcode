// 380. Insert Delete GetRandom O(1)

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */

#region Вариант 1 (мой, неправильно работает GetRandom)
public class RandomizedSet_380_1
{
    private readonly Dictionary<bool, HashSet<int>> _isUsedToNumberPairs;
    private readonly Random _random;

    public RandomizedSet_380_1()
    {
        _isUsedToNumberPairs = new Dictionary<bool, HashSet<int>>
        {
            [false] = [],
            [true] = []
        };

        _random = new Random();
    }

    public bool Insert(int val)
    {
        if (_isUsedToNumberPairs[false].Contains(val)
         || _isUsedToNumberPairs[true].Contains(val))
        {
            return false;
        }

        _isUsedToNumberPairs[false].Add(val);
        return true;
    }

    public bool Remove(int val)
    {
        if (!_isUsedToNumberPairs[false].Contains(val)
         && !_isUsedToNumberPairs[true].Contains(val))
        {
            return false;
        }

        if (!_isUsedToNumberPairs[false].Remove(val))
        {
            _isUsedToNumberPairs[true].Remove(val);
        }

        return true;
    }

    public int GetRandom()
    {
        if (_isUsedToNumberPairs[false].Count == 0)
        {
            _isUsedToNumberPairs[false] = _isUsedToNumberPairs[true];
            _isUsedToNumberPairs[true] = new HashSet<int>();
        }

        var random = _random.Next(0, _isUsedToNumberPairs[false].Count);

        var number = _isUsedToNumberPairs[false].ElementAt(random);
        _isUsedToNumberPairs[false].Remove(number);
        _isUsedToNumberPairs[true].Add(number);
        return number;
    }
}
#endregion

#region Вариант 2 (не мой) - Runtime 10 ms, Beats 100.00%
public class RandomizedSet
{
    private readonly List<int> _list;
    private readonly Dictionary<int, int> _dict;
    private readonly Random _random = new Random();

    public RandomizedSet()
    {
        _list = new List<int>();
        _dict = new  Dictionary<int, int>();
    }

    public bool Insert(int val)
    {
        if (_dict.ContainsKey(val))
        {
            return false;
        }

        _list.Add(val);
        _dict.Add(val, _list.Count - 1);

        return true;
    }

    public bool Remove(int val)
    {
        if (!_dict.ContainsKey(val))
        {
            return false;
        }

        var index = _dict[val];
        var lastElement = _list[^1];

        // move the last element to the place idx of the element to delete
        _list[index] = lastElement;
        _dict[lastElement] = index;

        // remove the last element
        _list.RemoveAt(_list.Count - 1);
        _dict.Remove(val);

        return true;
    }

    public int GetRandom()
    {
        var randomIndex = _random.Next(0, _list.Count);

        return _list[randomIndex];
    }
}
#endregion