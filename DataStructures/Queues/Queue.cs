using System.Collections;
using DataStructures.Nodes;

namespace DataStructures.Queues;

public class Queue<T> : IEnumerable<T>
{
    private int _count;

    public SinglyNode<T>? Front { get; private set; }
    public SinglyNode<T>? Back { get; private set; }
    
    public int Count => _count;

    public Queue()
    {
    }

    public Queue(T value) => Enqueue(value);

    public Queue(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (var value in values)
        {
            Enqueue(value);
        }
    }

    public bool IsEmpty() => Front is null;

    public void Clear()
    {
        Front = Back = null;
        _count = 0;
    }

    public void Enqueue(T value)
    {
        var node = new SinglyNode<T>(value);
        if (Back is null)
        {
            Front = Back = node;
        }
        else
        {
            Back = Back.Next = node;
        }

        _count++;
    }

    public T Dequeue()
    {
        if (Front is null) throw new NullReferenceException("Queue is empty");

        var value = Front.Data;
        Front = Front.Next;
        _count--;
        if (Front is null) Back = null;
        
        return value;
    }

    public T Peek()
    {
        if (Front is null) throw new NullReferenceException("Queue is empty");

        return Front.Data;
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
}