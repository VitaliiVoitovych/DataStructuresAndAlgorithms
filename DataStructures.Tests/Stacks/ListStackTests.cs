using DataStructures.Stacks;

namespace DataStructures.Tests.Stacks;

public class ListStackTests
{
    [Fact]
    public void IsEmpty()
    {
        var stack = new ListStack<int>();
        
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Clear()
    {
        var stack = new ListStack<int>([1, 2, 3, 4]);
        
        stack.Clear();
        
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Push()
    {
        var stack = new ListStack<int>();
        
        stack.Push(1);
        
        Assert.Equal(1, stack.Top);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Pop()
    {
        var stack = new ListStack<int>([1, 2, 3, 4]);
        
        var removedValue = stack.Pop();
        
        Assert.Equal(4, removedValue);
        Assert.Equal(3, stack.Count);
    }

    [Fact]
    public void Peek()
    {
        var stack = new ListStack<int>([1, 2, 3]);
        
        Assert.Equal(3, stack.Peek());
    }
}