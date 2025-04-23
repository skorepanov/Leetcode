// 706. Design HashMap
namespace CurrentTask;

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */

public class MyHashMap
{
    private readonly List<(int Key, int Value)>[] _buckets
        = new List<(int Key, int Value)>[1000];

    public MyHashMap() { }

    public void Put(int key, int value)
    {
        var hash = GetHash(key);

        if (Contains(key))
        {
            var bucket = _buckets[hash];
            var tuple = bucket.Single(t => t.Key == key);
            bucket.Remove(tuple);
            bucket.Add((key, value));
            return;
        }

        _buckets[hash] ??= new List<(int Key, int Value)>();
        _buckets[hash].Add((key, value));
    }

    public int Get(int key)
    {
        var hash = GetHash(key);

        if (_buckets[hash] is null)
        {
            return -1;
        }

        var tuple = _buckets[hash].SingleOrDefault(t => t.Key == key);

        if (tuple.Equals(default))
        {
            return -1;
        }

        return tuple.Value;
    }

    public void Remove(int key)
    {
        if (!Contains(key))
        {
            return;
        }

        var hash = GetHash(key);

        var tuple = _buckets[hash].Single(t => t.Key == key);
        _buckets[hash].Remove(tuple);
    }

    private bool Contains(int key)
    {
        var hash = GetHash(key);

        return _buckets[hash]?.Any(t => t.Key == key) is true;
    }

    private int GetHash(int key) => key % 1000;
}