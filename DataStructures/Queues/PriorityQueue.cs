using System;
using DataStructures.Nodes;

namespace DataStructures.Queues;

public class PriorityQueue<T>
{
    private int _count;

    public PriorityNode<T>? Head { get; private set; }
    
    public int Count => _count;

    public PriorityQueue()
    {
    }

    public PriorityQueue(T value, int priority) => Enqueue(value, priority);

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
            while (current != null && current.Priority > priority)
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
}