namespace DataStructures.Nodes;

public class PriorityNode<T>
{
    public T Data { get; init; }
    
    public int Priority { get; init; }
    
    public PriorityNode<T>? Next { get; internal set; }

    public PriorityNode(T data, int priority)
    {
        Data = data;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Data} with {Priority} priority";
    }
}