// 295. Find Median from Data Stream

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
public class MedianFinder
{
    private readonly PriorityQueue<int, int> _lower;
    private readonly PriorityQueue<int, int> _higher;

    public MedianFinder()
    {
        var comparer = Comparer<int>.Create((x, y) => y - x);

        _lower = new PriorityQueue<int, int>(comparer);
        _higher = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        if (_lower.Count == 0)
        {
            _lower.Enqueue(num, num);
            return;
        }

        if (_lower.Peek() >= num)
        {
            _lower.Enqueue(num, num);

            if (_lower.Count == _higher.Count + 2)
            {
                var replacedNum = _lower.Dequeue();
                _higher.Enqueue(replacedNum, replacedNum);
            }
        }
        else
        {
            _higher.Enqueue(num, num);

            if (_higher.Count > _lower.Count)
            {
                var replacedNum = _higher.Dequeue();
                _lower.Enqueue(replacedNum, replacedNum);
            }
        }
    }

    public double FindMedian()
    {
        if (_lower.Count == _higher.Count + 1)
        {
            return _lower.Peek();
        }

        return (_lower.Peek() + _higher.Peek()) / 2.0;
    }
}
