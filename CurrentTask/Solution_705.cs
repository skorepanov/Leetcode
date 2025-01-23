// 705. Design HashSet
namespace CurrentTask;

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */

public class MyHashSet
{
    private readonly List<int>[] _buckets = new List<int>[1000];

    public MyHashSet() { }

    public void Add(int key)
    {
        if (Contains(key))
        {
            return;
        }

        var hash = GetHash(key);

        _buckets[hash] ??= new List<int>();
        _buckets[hash].Add(key);
    }

    public void Remove(int key)
    {
        var hash = GetHash(key);

        if (_buckets[hash] is null)
        {
            return;
        }

        _buckets[hash].Remove(key);
    }

    public bool Contains(int key)
    {
        var hash = GetHash(key);

        return _buckets[hash]?.Contains(key) is true;
    }

    private int GetHash(int key) => key % 1000;
}
