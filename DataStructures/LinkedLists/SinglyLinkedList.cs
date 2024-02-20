using System.Collections;
using DataStructures.Nodes;

namespace DataStructures.LinkedLists;

public class SinglyLinkedList<T> : ILinkedList<T>
{
    private int _count;
    public SinglyNode<T>? Head { get; private set; }

    public SinglyNode<T>? Tail
    {
        get
        {
            var current = Head;
            while (current?.Next != null)
            {
                current = current.Next;
            }

            return current;
        }
    }

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
        Head = new SinglyNode<T>(value);
        _count = 1;
    }

    public bool IsEmpty() => Head is null;

    public void Clear()
    {
        Head = null;
        _count = 0;
    }

    public void AddAtHead(T value)
    {
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

        Tail.Next = new SinglyNode<T>(value);
        _count++;
    }

    public void InsertAfter(T element, T value)
    {
        if (Head is null) return;

        var current = Search(element) ?? throw new NullReferenceException("Not found");

        current.Next = new SinglyNode<T>(value) { Next = current.Next };
        _count++;
    }

    public void InsertBefore(T element, T value)
    {
        if (Head is null) return;

        var node = Search(element);
        var current = Head;

        while (current!.Next != node)
        {
            current = current.Next;
        }

        current.Next = new SinglyNode<T>(value) { Next = node };
        _count++;
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

        var node = Search(element) ?? throw new NullReferenceException("Not found");
        if (Head == node)
        {
            Head = node.Next;
        }
        else
        {
            var current = Head;
            while (current!.Next != node)
                current = current.Next;

            current.Next = node.Next;
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