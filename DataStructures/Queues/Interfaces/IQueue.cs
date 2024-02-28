namespace DataStructures.Queues.Interfaces;

public interface IQueue<T> : IEnumerable<T>
{
    bool IsEmpty();
    void Clear();
    void Enqueue(T value);
    T Dequeue();
    T Peek();
}