namespace DataStructures.Queues.Interfaces;

public interface IDeque<T> : IEnumerable<T>
{
    bool IsEmpty();
    void Clear();
    void PushFront(T value);
    void PushBack(T value);
    T PopFront();
    T PopBack();
    T PeekFront();
    T PeekBack();
}