using DataStructures.Queues;

namespace DataStructures.Tests.Queues;

public class ListQueueTests
{
    [Fact]
    public void IsEmpty()
    {
        var queue = new ListQueue<int>();
        
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Clear()
    {
        var queue = new ListQueue<int>([1, 2, 3, 4]);
        
        queue.Clear();
        
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Enqueue()
    {
        var queue = new ListQueue<int>(1);
        
        queue.Enqueue(2);
        
        Assert.Equal(2, queue.Back);
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Dequeue()
    {
        var queue = new ListQueue<int>([1, 2, 3, 4]);
        
        var removedValue = queue.Dequeue();
        
        Assert.Equal(1, removedValue);
        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Peek()
    {
        var queue = new ListQueue<int>([1, 2, 3]);
        
        Assert.Equal(1, queue.Peek());
    }
}