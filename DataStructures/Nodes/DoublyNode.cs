namespace DataStructures.Nodes;

public class DoublyNode<T>
{
    public T Data { get; init; }
    
    public DoublyNode<T>? Previous { get; internal set; }
    public DoublyNode<T>? Next { get; internal set; }

    public DoublyNode(T data) => Data = data;

    public override string? ToString()
    {
        return Data?.ToString();
    }
}