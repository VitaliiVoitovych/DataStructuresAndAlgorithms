using System.Collections;
using DataStructures.Nodes;

namespace DataStructures.Queues;

public class Deque<T> : IEnumerable<T>
{
    private int _count;
    
    public DoublyNode<T>? Front { get; private set; }
    public DoublyNode<T>? Back { get; private set; }
    
    public int Count => _count;

    public Deque()
    {
    }

    public Deque(T value) => SetFrontAndBack(value);

    public Deque(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (var value in values)
        {
            PushBack(value);
        }
    }

    private void SetFrontAndBack(T value)
    {
        Front = Back = new DoublyNode<T>(value);
        _count = 1;
    }
    
    public bool IsEmpty() => Front is null;

    public void Clear()
    {
        Front = Back = null;
        _count = 0;
    }
    
    public void PushFront(T value)
    {
        if (Front is null)
        {
            SetFrontAndBack(value);
            return;
        }

        var node = new DoublyNode<T>(value) { Next = Front };
        Front = Front.Previous = node;
        _count++;
    }

    public void PushBack(T value)
    {
        if (Back is null)
        {
            SetFrontAndBack(value);
            return;
        }

        var node = new DoublyNode<T>(value) { Previous = Back };
        Back = Back.Next = node;
        _count++;
    }

    public T PopFront()
    {
        if (Front is null) throw new NullReferenceException("Deque is empty");

        var node = Front;
        if (Front == Back) Front = Back = null;
        else
        {
            Front = Front!.Next;
            Front!.Previous = node!.Previous;
        }

        _count--;
        return node.Data;
    }

    public T PopBack()
    {
        if (Back is null) throw new NullReferenceException("Deque is empty");

        var node = Back;
        if (Front == Back) Front = Back = null;
        else
        {
            Back = Back!.Previous;
            Back!.Next = node!.Next;
        }
        
        _count--;
        return node.Data;
    }

    public T PeekFront()
    {
        if (Front is null) throw new NullReferenceException("Deque is empty");

        return Front.Data;
    }

    public T PeekBack()
    {
        if (Back is null) throw new NullReferenceException("Deque is empty");

        return Back.Data;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var current = Front;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return $"Deque : {Count} elements";
    }
}