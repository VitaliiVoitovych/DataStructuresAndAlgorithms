using System.Collections;
using DataStructures.Queues.Interfaces;

namespace DataStructures.Queues;

public class ListDeque<T> : IDeque<T>
{
    private readonly List<T> _dequeList;

    public T Front => _dequeList[0];
    public T Back => _dequeList[^1];
    
    public int Count => _dequeList.Count;

    public ListDeque()
    {
        _dequeList = [];
    }

    public ListDeque(T value) : this()
    {
        PushBack(value);
    }

    public ListDeque(IEnumerable<T> values) : this()
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (var value in values)
        {
            PushBack(value);
        }
    }

    public bool IsEmpty() => Count < 1;

    public void Clear()
    {
        _dequeList.Clear();
    }

    public void PushFront(T value)
    {
        _dequeList.Insert(0, value);
    }

    public void PushBack(T value)
    {
        _dequeList.Add(value);
    }

    public T PopFront()
    {
        if (IsEmpty()) throw new NullReferenceException("Deque is empty");
        
        var value = _dequeList[0];
        _dequeList.RemoveAt(0);

        return value;
    }

    public T PopBack()
    {
        if (IsEmpty()) throw new NullReferenceException("Deque is empty");
        
        var value = _dequeList[^1];
        _dequeList.RemoveAt(Count - 1);

        return value;
    }

    public T PeekFront()
    {
        if (IsEmpty()) throw new NullReferenceException("Deque is empty");
        
        return _dequeList[0];
    }

    public T PeekBack()
    {
        if (IsEmpty()) throw new NullReferenceException("Deque is empty");
        
        return _dequeList[^1];
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _dequeList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}