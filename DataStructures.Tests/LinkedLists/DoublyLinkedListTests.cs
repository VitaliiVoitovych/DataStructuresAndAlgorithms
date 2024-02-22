using DataStructures.LinkedLists;

namespace DataStructures.Tests.LinkedLists;

public class DoublyLinkedListTests
{
    private void CollectionEquals<T>(T[] expectedValues, IEnumerable<T> actualValues)
    {
        var i = 0;
        foreach (var value in actualValues)
        {
            Assert.Equal(expectedValues[i], value);
            i++;
        }
    }

    [Fact]
    public void IsEmpty()
    {
        var doublyLinkedList = new DoublyLinkedList<int>();
        
        Assert.True(doublyLinkedList.IsEmpty());
    }

    [Fact]
    public void Clear()
    {
        var doublyLinkedList = new DoublyLinkedList<int>([1, 2, 3, 4]);
        
        doublyLinkedList.Clear();
        
        Assert.True(doublyLinkedList.IsEmpty());
    }
    
    [Fact]
    public void AddAtHead()
    {
        var doublyLinkedList = new DoublyLinkedList<int>(1);
        
        doublyLinkedList.AddAtHead(2);
        
        Assert.Equal(2, doublyLinkedList.Head?.Data);
    }
    
    [Fact]
    public void AddAtTail()
    {
        var doublyLinkedList = new DoublyLinkedList<int>(1);
        
        doublyLinkedList.AddAtTail(2);
        
        Assert.Equal(2, doublyLinkedList.Tail?.Data);
    }

    [Fact]
    public void InsertAfter()
    {
        var doublyLinkedList = new DoublyLinkedList<int>([1, 2 ,3 ,4]);
        
        doublyLinkedList.InsertAfter(4, 5);
        Assert.Equal(5, doublyLinkedList.Tail?.Data);
        CollectionEquals([1, 2, 3, 4, 5], doublyLinkedList);
    }

    [Fact]
    public void InsertAfterInNullableValueList()
    {
        var doublyLinkedList = new DoublyLinkedList<int?>([1, null, 3]);
        
        doublyLinkedList.InsertAfter(null, 2);
        
        CollectionEquals([1, null, 2, 3], doublyLinkedList);
    }
    
    [Fact]
    public void InsertBefore()
    {
        var doublyLinkedList = new DoublyLinkedList<int>([1, 2 ,3 ,4]);
        
        doublyLinkedList.InsertBefore(1, 5);
        Assert.Equal(5, doublyLinkedList.Head?.Data);
        CollectionEquals([5, 1, 2, 3, 4], doublyLinkedList);
    }

    [Fact]
    public void InsertBeforeInNullableValueList()
    {
        var doublyLinkedList = new DoublyLinkedList<int?>([1, null, 3]);
        
        doublyLinkedList.InsertBefore(null, 2);
        
        CollectionEquals([1, 2, null, 3], doublyLinkedList);
    }
    
    [Fact]
    public void RemoveFromHead()
    {
        var doublyLinkedList = new DoublyLinkedList<int>([1, 2, 3]);
        
        doublyLinkedList.RemoveFromHead();
        
        CollectionEquals([2, 3], doublyLinkedList);
    }

    [Fact]
    public void RemoveFromHeadInOneElementList()
    {
        var doublyLinkedList = new DoublyLinkedList<int>(1);
        
        doublyLinkedList.RemoveFromHead();
        
        Assert.Null(doublyLinkedList.Tail);
    }
    
    [Fact]
    public void RemoveFromTail()
    {
        var doublyLinkedList = new DoublyLinkedList<int>([1, 2, 3]);
        
        doublyLinkedList.RemoveFromTail();
        
        CollectionEquals([1, 2], doublyLinkedList);
    }

    [Fact]
    public void RemoveFromTailInOneElementList()
    {
        var doublyLinkedList = new DoublyLinkedList<int>(1);
        
        doublyLinkedList.RemoveFromTail();
        
        Assert.Null(doublyLinkedList.Head);
    }
    
    [Fact]
    public void Remove()
    {
        var doublyLinkedList = new DoublyLinkedList<int>([1, 2]);
        
        doublyLinkedList.Remove(2);
        
        CollectionEquals([1], doublyLinkedList);
    }
}