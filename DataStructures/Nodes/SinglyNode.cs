namespace DataStructures.Nodes;

public class SinglyNode<T>
{
    public T Data { get; set; }

    public SinglyNode<T>? Next { get; internal set; }

    public SinglyNode(T data) => Data = data;

    public override string? ToString()
    {
        return Data?.ToString();
    }
}