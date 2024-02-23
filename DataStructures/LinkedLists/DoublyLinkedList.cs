using System.Collections;
using DataStructures.Nodes;

namespace DataStructures.LinkedLists;

public class DoublyLinkedList<T> : ILinkedList<T>
{
    private int _count;

    public DoublyNode<T>? Head { get; private set; }
    public DoublyNode<T>? Tail { get; private set; }
    
    public int Count => _count;

    public DoublyLinkedList()
    {
    }

    public DoublyLinkedList(T value)
    {
        SetHeadAndTail(value);
    }

    public DoublyLinkedList(IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (var value in values)
        {
            AddAtTail(value);
        }
    }

    private void SetHeadAndTail(T value)
    {
        Head = Tail = new DoublyNode<T>(value);
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
        
        var node = new DoublyNode<T>(value) { Next = Head };
        Head = Head.Previous = node;
        _count++;
    }

    public void AddAtTail(T value)
    {
        if (Tail is null)
        {
            SetHeadAndTail(value);
            return;
        }

        var node = new DoublyNode<T>(value) { Previous = Tail};
        Tail = Tail.Next = node;
        _count++;
    }

    public void InsertAfter(T element, T value)
    {
        var node = Search(element) ?? throw new NullReferenceException("Not found");

        if (Tail == node)
        {
            AddAtTail(value);
            return;
        }
        
        node.Next = node.Next!.Previous = new DoublyNode<T>(value) { Previous = node, Next = node.Next};
        _count++;
    }

    public void InsertBefore(T element, T value)
    {
        var node = Search(element) ?? throw new NullReferenceException("Not found");

        if (Head == node)
        {
            AddAtHead(value);
            return;
        }
        
        node.Previous = node.Previous!.Next = new DoublyNode<T>(value) { Previous = node.Previous, Next = node};
        _count++;
    }

    public void RemoveFromHead()
    {
        if (Head is null) return;

        Remove(Head.Data);
    }

    public void RemoveFromTail()
    {
        if (Head is null) return;

        Remove(Tail!.Data);
    }

    public void Remove(T element)
    {
        if (Head is null) return;
        
        var node = Search(element) ?? throw new NullReferenceException("Not found");
        
        if (Head == Tail)
        {
            Head = Tail = null;
        }
        else if (Head == node)
        {
            Head = Head.Next;
            Head!.Previous = null;
        }
        else if (node == Tail)
        {
            Tail = Tail!.Previous;
            Tail!.Next = null;
        }
        else
        {
            node.Previous!.Next = node.Next;
            node.Next!.Previous = node.Previous;
        }
        _count--;
    }

    public DoublyNode<T>? Search(T element)
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
        return $"Doubly Linked List: {Count} elements";
    }
}