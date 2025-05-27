// 622. Design Circular Queue

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */

#region Вариант 1 - с помощью массива, Runtime 1 ms, Beats 100.00%
public class MyCircularQueue_622_1
{
    private readonly int[] _data;
    private int _head;
    private int _tail;

    public MyCircularQueue_622_1(int k)
    {
        _data = new int[k];
        _head = -1;
        _tail = -1;
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
        {
            return false;
        }

        if (IsEmpty())
        {
            _head = _tail = 0;
            _data[_tail] = value;
            return true;
        }

        if (_tail == _data.Length - 1)
        {
            _tail = 0;
            _data[_tail] = value;
            return true;
        }

        _tail++;
        _data[_tail] = value;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
        {
            return false;
        }

        if (_head == _tail)
        {
            _head = _tail = -1;
            return true;
        }

        if (_head == _data.Length - 1)
        {
            _head = 0;
            return true;
        }

        _head++;
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
        {
            return -1;
        }

        return _data[_head];
    }

    public int Rear()
    {
        if (IsEmpty())
        {
            return -1;
        }

        return _data[_tail];
    }

    public bool IsEmpty()
    {
        return _head == -1;
    }

    public bool IsFull()
    {
        if ((_head - _tail == 1)
         || (_head == 0 && _tail == _data.Length - 1))
        {
            return true;
        }

        return false;
    }
}
#endregion

#region Вариант 2 - с помощью Singly-Linked List, Runtime 1 ms, Beats 100.00%
public class MyCircularQueue_622_2
{
    private Node _head;
    private Node _tail;
    private int _count;
    private readonly int _capacity;

    public MyCircularQueue_622_2(int k)
    {
        _capacity = k;
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
        {
            return false;
        }

        var newNode = new Node(value);

        if (this._count == 0)
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail.NextNode = newNode;
            _tail = newNode;
        }

        _count++;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
        {
            return false;
        }

        _head = _head.NextNode;
        _count--;
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
        {
            return -1;
        }

        return _head.Value;
    }

    public int Rear()
    {
        if (IsEmpty())
        {
            return -1;
        }

        return _tail.Value;
    }

    public bool IsEmpty()
    {
        return _count == 0;
    }

    public bool IsFull()
    {
        return _count == _capacity;
    }

    private class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }

        public Node(int value)
        {
            Value = value;
            NextNode = null;
        }
    }
}
#endregion
