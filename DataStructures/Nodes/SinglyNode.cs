namespace DataStructures.Nodes;

public class SinglyNode<T>
{
    public T Data { get; init; }

    public SinglyNode<T>? Next { get; internal set; }

    public SinglyNode(T data) => Data = data;

    public override string? ToString()
    {
        return Data?.ToString();
    }
}