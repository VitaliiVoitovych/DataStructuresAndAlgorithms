using System.Collections;
using DataStructures.Nodes;
using DataStructures.Stacks.Interfaces;

namespace DataStructures.Stacks;

/// <summary>
/// Based on Singly Linked List
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
public class Stack<T> : IStack<T>
{
    private int _count;
    
    public SinglyNode<T>? Top { get; private set; }
    public int Count => _count;

    public Stack()
    {
    }

    public Stack(T value) => Push(value);

    public Stack(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        
        foreach (var value in values)
        {
            Push(value);
        }
    }

    public bool IsEmpty() => Top is null;

    public void Clear()
    {
        Top = null;
        _count = 0;
    }

    public void Push(T value)
    {
        Top = new SinglyNode<T>(value) { Next = Top };
        _count++;
    }

    public T Pop()
    {
        if (Top is null) throw new NullReferenceException("Stack is empty");
        
        var value = Top.Data;
        Top = Top.Next;
        _count--;
        return value;
    }

    public T Peek()
    {
        if (Top is null) throw new NullReferenceException("Stack is empty");
        
        return Top.Data;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var current = Top;
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
        return $"Stack: {Count} elements";
    }
}