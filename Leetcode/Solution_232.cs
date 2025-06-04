// 232. Implement Queue using Stacks

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

public class MyQueue
{
    private readonly Stack<int> _stack = new ();

    public MyQueue() { }

    public void Push(int x)
    {
        _stack.Push(x);
    }

    public int Pop()
    {
        var stack = new Stack<int>();

        while (_stack.Count > 0)
        {
            var x = _stack.Pop();
            stack.Push(x);
        }

        var result = stack.Pop();

        while (stack.Count > 0)
        {
            var x = stack.Pop();
            _stack.Push(x);
        }

        return result;
    }

    public int Peek()
    {
        var stack = new Stack<int>();

        while (_stack.Count > 0)
        {
            var x = _stack.Pop();
            stack.Push(x);
        }

        var result = stack.Peek();

        while (stack.Count > 0)
        {
            var x = stack.Pop();
            _stack.Push(x);
        }

        return result;
    }

    public bool Empty()
    {
        return _stack.Count == 0;
    }
}