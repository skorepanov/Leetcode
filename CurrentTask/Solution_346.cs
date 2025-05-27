// 346. Moving Average from Data Stream

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */
public class MovingAverage
{
    private readonly Queue<int> _queue;
    private readonly int _size;
    private double _sum;

    public MovingAverage(int size)
    {
        _queue = new Queue<int>();
        _size = size;
        _sum = 0;
    }

    public double Next(int val)
    {
        if (_queue.Count >= _size)
        {
            var removed = _queue.Dequeue();
            _sum -= removed;
        }

        _queue.Enqueue(val);
        _sum += val;

        return _sum / _queue.Count;
    }
}