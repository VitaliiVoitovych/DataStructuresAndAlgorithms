namespace DataStructures.LinkedLists.Interfaces;

public interface ILinkedList<T> : IEnumerable<T>
{
    bool IsEmpty();
    void Clear();
    void AddAtHead(T value);
    void AddAtTail(T value);
    void InsertAfter(T element, T value);
    void InsertBefore(T element, T value);
    void RemoveFromHead();
    void RemoveFromTail();
    void Remove(T element);
}
