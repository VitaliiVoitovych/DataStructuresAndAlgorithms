using System.Collections;
using DataStructures.LinkedLists.Interfaces;
using DataStructures.Nodes;

namespace DataStructures.LinkedLists;

public class SinglyLinkedList<T> : ILinkedList<T>
{
    private int _count;
    public SinglyNode<T>? Head { get; private set; }

    public SinglyNode<T>? Tail { get; private set; }

    public int Count => _count;
    
    public SinglyLinkedList()
    {
    }

    public SinglyLinkedList(T value)
    {
        SetHeadAndTail(value);
    }

    public SinglyLinkedList(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        
        foreach (var value in values)
        {
            AddAtTail(value);
        }
    }

    private void SetHeadAndTail(T value)
    {
        Head = Tail = new SinglyNode<T>(value);
        _count = 1;
    }

    public bool IsEmpty() => Head is null;

    public void Clear()
    {
        Head = Tail = null;
        _count = 0;
    }

    public void AddAtHead(T value)
    {
        if (Head is null)
        {
            SetHeadAndTail(value);
            return;
        }
        Head = new SinglyNode<T>(value) { Next = Head };
        _count++;
    }

    public void AddAtTail(T value)
    {
        if (Tail is null)
        {
            SetHeadAndTail(value);
            return;
        }

        Tail = Tail.Next = new SinglyNode<T>(value);
        _count++;
    }

    public void InsertAfter(T element, T value)
    {
        if (Head is null) return;

        var current = Search(element) ?? throw new NullReferenceException("Not found");

        if (current == Tail)
        {
            AddAtTail(value);
            return;
        }
        
        current.Next = new SinglyNode<T>(value) { Next = current.Next };
        _count++;
    }

    public void InsertBefore(T element, T value)
    {
        if (Head is null) return;
        
        if (Head.Data!.Equals(element))
        {
            AddAtHead(value);
        }
        else
        {
            var previous = default(SinglyNode<T>);
            var current = Head;
            while (current != null && !current.Data!.Equals(element))
            {
                previous = current;
                current = current.Next;
            }
        
            previous!.Next = current != null ? new SinglyNode<T>(value) { Next = current } : throw new NullReferenceException("Not Found");
            _count++;
        }
    }

    public void RemoveFromHead()
    {
        if (Head is null) return;
        
        Remove(Head.Data);
    }

    public void RemoveFromTail()
    {
        if (Tail is null) return;
        
        Remove(Tail.Data);
    }

    public void Remove(T element)
    {
        if (Head is null) return;

        if (Head == Tail)
        {
            Head = Tail = null;
        }
        else if (Head.Data!.Equals(element))
        {
            Head = Head.Next;
        }
        else
        {
            var previous = default(SinglyNode<T>);
            var current = Head;
            while (current != null && !current.Data!.Equals(element))
            {
                previous = current;
                current = current.Next;
            }

            previous!.Next = current != null ? current.Next : throw new NullReferenceException("Not found");
            if (current == Tail) Tail = previous;
        }
        _count--;
    }

    public SinglyNode<T>? Search(T element)
    {
        var current = Head;
        while (current != null && !current.Data!.Equals(element))
        {
            current = current.Next;
        }

        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;
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
        return $"Singly Linked List: {Count} elements";
    }
}