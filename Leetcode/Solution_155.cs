// 155. Min Stack

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

public class MinStack
{
    private Node _top;
    private Node _min;

    public MinStack() { }

    public void Push(int val)
    {
        var node = new Node(val);

        if (_top is null)
        {
            _top = node;
            _min = node;
            return;
        }

        node.Prev = _top;
        _top = node;

        if (node.Value < _min.Value)
        {
            node.Greater = _min;
            _min = node;
        }
    }

    public void Pop()
    {
        if (_top is null)
        {
            return;
        }

        if (_top == _min)
        {
            _min = _min.Greater;
        }

        _top = _top.Prev;
    }

    public int Top()
    {
        return _top?.Value ?? 0;
    }

    public int GetMin()
    {
        return _min?.Value ?? 0;
    }

    private class Node
    {
        public int Value { get; set; }
        public Node Prev { get; set; }
        public Node Greater { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
