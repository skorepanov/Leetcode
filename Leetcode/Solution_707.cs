// 707. Design Linked List

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */

// Doubly linked list
public class MyLinkedList_707
{
    private DoublyListNode? _head;
    private DoublyListNode? _tail;
    private int _size = 0;

    public int Get(int index)
    {
        if (_head is null || index < 0 || index >= _size)
        {
            return -1;
        }

        var currentNode = _head;

        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
        }

        return currentNode.Value;
    }

    public void AddAtHead(int val)
    {
        var newNode = new DoublyListNode(val);

        if (_head != null)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
        }
        else
        {
            _tail = newNode;
        }

        _head = newNode;
        _size++;
    }

    public void AddAtTail(int val)
    {
        var newNode = new DoublyListNode(val);

        if (_tail != null)
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
        }
        else
        {
            _head = newNode;
        }

        _tail = newNode;
        _size++;
    }

    public void AddAtIndex(int index, int val)
    {
        if (index < 0 || index > _size)
        {
            return;
        }

        if (index == 0)
        {
            AddAtHead(val);
            return;
        }

        if (index == _size)
        {
            AddAtTail(val);
            return;
        }

        var previousNode = _head;

        for (var i = 1; i < index; i++)
        {
            previousNode = previousNode.Next;
        }

        var newNode = new DoublyListNode(val);

        newNode.Prev = previousNode;
        newNode.Next = previousNode.Next;
        previousNode.Next.Prev = newNode;
        previousNode.Next = newNode;

        _size++;
    }

    public void DeleteAtIndex(int index)
    {
        if (_head is null || index < 0 || index >= _size)
        {
            return;
        }

        if (index == 0)
        {
            // delete head
            if (_size == 1)
            {
                _head = _tail = null;
                _size--;
                return;
            }

            _head.Next.Prev = null;
            _head = _head.Next;

            _size--;
            return;
        }

        if (index == _size - 1)
        {
            // delete tail
            _tail.Prev.Next = null;
            _tail = _tail.Prev;

            _size--;
            return;
        }

        // delete at index
        var previousNode = _head;

        for (var i = 1; i < index; i++)
        {
            previousNode = previousNode.Next;
        }

        previousNode.Next.Next.Prev = previousNode;
        previousNode.Next = previousNode.Next.Next;
        _size--;
    }


    private class DoublyListNode
    {
        public readonly int Value;
        public DoublyListNode? Prev { get; set; }
        public DoublyListNode? Next { get; set; }

        public DoublyListNode(int value)
        {
            Value = value;
        }
    }
}

/*
// Singly linked list
public class MyLinkedList
{
    private SinglyListNode? _head;
    private int _size = 0;

    public MyLinkedList()
    {

    }

    public int Get(int index)
    {
        if (_head is null || index < 0 || index >= _size)
        {
            return -1;
        }

        var currentNode = _head;

        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
        }

        return currentNode.Value;
    }

    public void AddAtHead(int val)
    {
        AddAtIndex(0, val);
    }

    public void AddAtTail(int val)
    {
        AddAtIndex(_size, val);
    }

    public void AddAtIndex(int index, int val)
    {
        if (index < 0 || index > _size)
        {
            return;
        }

        var newNode = new SinglyListNode(val);

        if (index == 0)
        {
            newNode.Next = _head;
            _head = newNode;
            _size++;
            return;
        }

        var previousNode = _head;

        for (var i = 1; i < index; i++)
        {
            previousNode = previousNode.Next;
        }

        newNode.Next = previousNode.Next;
        previousNode.Next = newNode;

        _size++;
    }

    public void DeleteAtIndex(int index)
    {
        if (_head is null || index < 0 || index >= _size)
        {
            return;
        }

        if (index == 0)
        {
            _head = _head.Next;
            _size--;
            return;
        }

        var previousNode = _head;

        for (var i = 1; i < index; i++)
        {
            previousNode = previousNode.Next;
        }

        previousNode.Next = previousNode.Next?.Next;
        _size--;
    }

    private class SinglyListNode
    {
        public readonly int Value;
        public SinglyListNode? Next { get; set; }

        public SinglyListNode(int value)
        {
            Value = value;
        }
    }
}
*/
