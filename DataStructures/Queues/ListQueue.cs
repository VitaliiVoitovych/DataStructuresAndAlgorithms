using System.Collections;
using DataStructures.Queues.Interfaces;

namespace DataStructures.Queues;

public class ListQueue<T> : IQueue<T>
{
    private readonly List<T> _queueList;

    public T Front => _queueList[0];
    public T Back => _queueList[^1];
    
    public int Count => _queueList.Count;
    
    public ListQueue()
    {
        _queueList = [];
    }

    public ListQueue(T value) : this()
    {
        Enqueue(value);
    }

    public ListQueue(IEnumerable<T> values) : this()
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (var value in values)
        {
            Enqueue(value);
        }
    }

    public bool IsEmpty() => Count < 1;

    public void Clear()
    {
        _queueList.Clear();
    }

    public void Enqueue(T value)
    {
        _queueList.Add(value);
    }

    public T Dequeue()
    {
        if (IsEmpty()) throw new NullReferenceException("Queue is empty");
        
        var value = _queueList[0];
        _queueList.RemoveAt(0);

        return value;
    }

    public T Peek()
    {
        if (IsEmpty()) throw new NullReferenceException("Queue is empty");
        
        return _queueList[0];
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _queueList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}