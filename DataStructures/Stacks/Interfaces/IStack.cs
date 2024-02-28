namespace DataStructures.Stacks.Interfaces;

public interface IStack<T> : IEnumerable<T>
{
    bool IsEmpty();
    void Clear();
    void Push(T value);
    T Pop();
    T Peek();
}