using DataStructures.Nodes;

namespace DataStructures.Queues;

public class LinkedPriorityQueue<T>
{
    private int _count;

    public PriorityNode<T>? Head { get; private set; }
    
    public int Count => _count;

    public LinkedPriorityQueue()
    {
    }

    public LinkedPriorityQueue(T value, int priority)
    {
        Enqueue(value, priority);
    }
    
    public bool IsEmpty() => Head is null;

    public void Clear()
    {
        Head = null;
        _count = 0;
    }
    
    public void Enqueue(T value, int priority)
    {
        if (Head is null)
        {
            Head = new PriorityNode<T>(value, priority);
            _count = 1;
        }
        else if (Head.Priority < priority)
        {
            Head = new PriorityNode<T>(value, priority) { Next = Head };
            _count++;
        }
        else
        {
            var previous = default(PriorityNode<T>);
            var current = Head;
            while (current is not null && current.Priority > priority)
            {
                previous = current;
                current = current.Next;
            }

            previous!.Next = new PriorityNode<T>(value, priority) { Next = current };
            _count++;
        }
    }

    public T Dequeue()
    {
        if (Head is null) throw new NullReferenceException("Priority Queue is empty");
        
        var value = Head.Data;
        Head = Head.Next;
        _count--;

        return value;
    }

    public T Peek()
    {
        if (Head is null) throw new NullReferenceException("Priority Queue is empty");
        
        return Head.Data;
    }

    public override string ToString() => $"Priority Queue: {Count} elements";
}