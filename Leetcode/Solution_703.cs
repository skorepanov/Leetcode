// 703. Kth Largest Element in a Stream

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

public class KthLargest
{
    private readonly PriorityQueue<int, int> _nums;
    private readonly int _k;

    public KthLargest(int k, int[] nums)
    {
        _nums = new PriorityQueue<int, int>();
        _k = k;

        foreach (var num in nums)
        {
            _nums.Enqueue(num, num);

            if (_nums.Count > _k)
            {
                _nums.Dequeue();
            }
        }
    }

    public int Add(int val)
    {
        if (_nums.Count < _k || _nums.Peek() < val)
        {
            _nums.Enqueue(val, val);

            if (_nums.Count > _k)
            {
                _nums.Dequeue();
            }
        }

        return _nums.Peek();
    }
}
