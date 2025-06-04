// 225. Implement Stack using Queues

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */

public class MyStack
{
    private readonly Queue<int> _queue = new ();

    public MyStack() { }

    public void Push(int x)
    {
        _queue.Enqueue(x);
    }

    public int Pop()
    {
        var size = _queue.Count;

        for (int i = 0; i < size - 1; i++)
        {
            var t = _queue.Dequeue();
            _queue.Enqueue(t);
        }

        var result = _queue.Dequeue();
        return result;
    }

    public int Top()
    {
        var size = _queue.Count;

        for (int i = 0; i < size - 1; i++)
        {
            var t = _queue.Dequeue();
            _queue.Enqueue(t);
        }

        var result = _queue.Dequeue();
        _queue.Enqueue(result);

        return result;
    }

    public bool Empty()
    {
        return _queue.Count == 0;
    }
}
