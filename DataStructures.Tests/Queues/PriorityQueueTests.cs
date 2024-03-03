using DataStructures.Queues;

namespace DataStructures.Tests.Queues;

public class PriorityQueueTests
{
    [Fact]
    public void Enqueue()
    {
        var priorityQueue = new PriorityQueue<int>();

        priorityQueue.Enqueue(120, 30);
        priorityQueue.Enqueue(220, 10);
        priorityQueue.Enqueue(203, 20);
        priorityQueue.Enqueue(201, 40);
        priorityQueue.Enqueue(320, 15);
        
        Assert.Equal(5, priorityQueue.Count);
    }

    [Fact]
    public void Dequeue()
    {
        var priorityQueue = new PriorityQueue<int>();

        priorityQueue.Enqueue(120, 30);
        priorityQueue.Enqueue(220, 10);
        priorityQueue.Enqueue(203, 20);
        priorityQueue.Enqueue(201, 40);
        priorityQueue.Enqueue(320, 15);

        priorityQueue.Dequeue();
        
        Assert.Equal(4, priorityQueue.Count);
    }
}