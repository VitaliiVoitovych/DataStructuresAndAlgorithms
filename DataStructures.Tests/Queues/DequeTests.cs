using DataStructures.Queues;

namespace DataStructures.Tests.Queues;

public class DequeTests
{
    [Fact]
    public void IsEmpty()
    {
        var deque = new Deque<int>();
        
        Assert.True(deque.IsEmpty());
    }

    [Fact]
    public void Clear()
    {
        var deque = new Deque<int>([1, 2, 3, 4]);
        
        deque.Clear();
        
        Assert.True(deque.IsEmpty());
    }

    [Fact]
    public void PushFront()
    {
        var deque = new Deque<int>(1);
        
        deque.PushFront(2);
        
        Assert.Equal(2, deque.Front?.Data);
    }
    
    [Fact]
    public void PushBack()
    {
        var deque = new Deque<int>(1);
        
        deque.PushBack(2);
        
        Assert.Equal(2, deque.Back?.Data);
    }
    
    [Fact]
    public void PopFront()
    {
        var deque = new Deque<int>([1, 2, 3, 4]);

        var value = deque.PopFront();
        
        Assert.Equal(1, value);
        Assert.Equal(2, deque.Front?.Data);
    }
    
    [Fact]
    public void PopBack()
    {
        var deque = new Deque<int>([1, 2, 3, 4]);

        var value = deque.PopBack();
        
        Assert.Equal(4, value);
        Assert.Equal(3, deque.Back?.Data);
    }
    
    [Fact]
    public void PeekFront()
    {
        var deque = new Deque<int>([1, 2, 3, 4]);

        var value = deque.PeekFront();
        
        Assert.Equal(1, value);
        Assert.Equal(4, deque.Count);
    }
    
    [Fact]
    public void PeekBack()
    {
        var deque = new Deque<int>([1, 2, 3, 4]);

        var value = deque.PeekBack();
        
        Assert.Equal(4, value);
        Assert.Equal(4, deque.Count);
    }
}