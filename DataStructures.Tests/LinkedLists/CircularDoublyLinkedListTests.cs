using DataStructures.LinkedLists;

namespace DataStructures.Tests.LinkedLists;

public class CircularDoublyLinkedListTests
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
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>();
        
        Assert.True(circularDoublyLinkedList.IsEmpty());
    }

    [Fact]
    public void Clear()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>([1, 2, 3, 4]);
        
        circularDoublyLinkedList.Clear();
        
        Assert.True(circularDoublyLinkedList.IsEmpty());
    }
    
    [Fact]
    public void AddAtHead()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>(1);
        
        circularDoublyLinkedList.AddAtHead(2);
        
        Assert.Equal(2, circularDoublyLinkedList.Head?.Data);
    }
    
    [Fact]
    public void AddAtTail()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>(1);
        
        circularDoublyLinkedList.AddAtTail(2);
        
        Assert.Equal(2, circularDoublyLinkedList.Tail?.Data);
    }

    [Fact]
    public void InsertAfter()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>([1, 2 ,3 ,4]);
        
        circularDoublyLinkedList.InsertAfter(4, 5);
        Assert.Equal(5, circularDoublyLinkedList.Tail?.Data);
        CollectionEquals([1, 2, 3, 4, 5], circularDoublyLinkedList);
    }

    [Fact]
    public void InsertAfterInNullableValueList()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int?>([1, null, 3]);
        
        circularDoublyLinkedList.InsertAfter(null, 2);
        
        CollectionEquals([1, null, 2, 3], circularDoublyLinkedList);
    }
    
    [Fact]
    public void InsertBefore()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>([1, 2 ,3 ,4]);
        
        circularDoublyLinkedList.InsertBefore(1, 5);
        Assert.Equal(5, circularDoublyLinkedList.Head?.Data);
        CollectionEquals([5, 1, 2, 3, 4], circularDoublyLinkedList);
    }

    [Fact]
    public void InsertBeforeInNullableValueList()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int?>([1, null, 3]);
        
        circularDoublyLinkedList.InsertBefore(null, 2);
        
        CollectionEquals([1, 2, null, 3], circularDoublyLinkedList);
    }
    
    [Fact]
    public void RemoveFromHead()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>([1, 2, 3]);
        
        circularDoublyLinkedList.RemoveFromHead();
        
        CollectionEquals([2, 3], circularDoublyLinkedList);
    }

    [Fact]
    public void RemoveFromHeadInOneElementList()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>(1);
        
        circularDoublyLinkedList.RemoveFromHead();
        
        Assert.Null(circularDoublyLinkedList.Tail);
    }
    
    [Fact]
    public void RemoveFromTail()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>([1, 2, 3]);
        
        circularDoublyLinkedList.RemoveFromTail();
        
        CollectionEquals([1, 2], circularDoublyLinkedList);
    }

    [Fact]
    public void RemoveFromTailInOneElementList()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>(1);
        
        circularDoublyLinkedList.RemoveFromTail();
        
        Assert.Null(circularDoublyLinkedList.Head);
    }
    
    [Fact]
    public void Remove()
    {
        var circularDoublyLinkedList = new CircularDoublyLinkedList<int>([1, 2, 3]);
        
        circularDoublyLinkedList.Remove(2);
        
        CollectionEquals([1], circularDoublyLinkedList);
    }
}