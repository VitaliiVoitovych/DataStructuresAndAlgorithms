using System.Collections;
using DataStructures.Stacks.Interfaces;

namespace DataStructures.Stacks;

public class ListStack<T> : IStack<T>
{
    private readonly List<T> _stackList;

    public T Top => _stackList[^1];
    public int Count => _stackList.Count;
    
    public ListStack()
    {
        _stackList = [];
    }

    public ListStack(T value) : this()
    {
        Push(value);
    }

    public ListStack(IEnumerable<T> values) : this()
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (var value in values)
        {
            Push(value);
        }
    }

    public bool IsEmpty() => Count < 1;
    
    public void Clear() => _stackList.Clear();

    public void Push(T value)
    {
        _stackList.Add(value);
    }

    public T Pop()
    {
        if (IsEmpty()) throw new NullReferenceException("Stack is empty");
        
        var value = _stackList[^1];
        _stackList.RemoveAt(Count - 1);
        return value;
    }

    public T Peek()
    {
        if (IsEmpty()) throw new NullReferenceException("Stack is empty");
        
        return _stackList[^1];
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _stackList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}