using DataStructures.LinkedLists;

namespace DataStructures.Tests.LinkedLists;

public class CircularLinkedListTests
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
        var circularLinkedList = new CircularLinkedList<int>();

        Assert.True(circularLinkedList.IsEmpty());
    }

    [Fact]
    public void Clear()
    {
        var circularLinkedList = new CircularLinkedList<int>([1, 2, 3, 4, 5]);
        
        circularLinkedList.Clear();
        
        Assert.True(circularLinkedList.IsEmpty());
    }
    
    [Fact]
    public void AddAtHead()
    {
        var circularLinkedList = new CircularLinkedList<int>(1);
        
        circularLinkedList.AddAtHead(2);
        
        Assert.Equal(2, circularLinkedList.Head?.Data);
    }
    
    [Fact]
    public void AddAtTail()
    {
        var circularLinkedList = new CircularLinkedList<int>(1);
        
        circularLinkedList.AddAtTail(2);
        
        Assert.Equal(2, circularLinkedList.Tail?.Data);
    }

    [Fact]
    public void InsertAfter()
    {
        var circularLinkedList = new CircularLinkedList<int>([1, 2]);
        
        circularLinkedList.InsertAfter(1, 3);
        
        int[] resultArray = [1, 3, 2];

        CollectionEquals(resultArray, circularLinkedList);
    }

    [Fact]
    public void InsertAfterInNullableValueList()
    {
        var nullableList = new CircularLinkedList<int?>([1, null]);
        
        nullableList.InsertAfter(null, 3);
        
        int?[] resultNullableArray = [1, null, 3];
        CollectionEquals(resultNullableArray, nullableList);
    }
    
    [Fact]
    public void InsertBefore()
    {
        var circularLinkedList = new CircularLinkedList<int>([1, 2]);
        
        circularLinkedList.InsertBefore(2, 3);

        int[] resultArray = [1, 3, 2];

        CollectionEquals(resultArray, circularLinkedList);
    }

    [Fact]
    public void InsertBeforeInNullableValueList()
    {
        var nullableList = new CircularLinkedList<int?>([1, null]);
        
        nullableList.InsertBefore(null, 3);
        
        int?[] resultNullableArray = [1, 3, null];
        CollectionEquals(resultNullableArray, nullableList);
    }
    
    [Fact]
    public void RemoveFromHead()
    {
        var circularLinkedList = new CircularLinkedList<int>([1, 2]);
        
        circularLinkedList.RemoveFromHead();
        
        Assert.Equal(2, circularLinkedList.Head?.Data);
    }

    [Fact]
    public void RemoveFromHeadInOneElementList()
    {
        var circularLinkedList = new CircularLinkedList<int>(1);
        
        circularLinkedList.RemoveFromHead();
        
        Assert.Null(circularLinkedList.Tail?.Data);
    }
    
    [Fact]
    public void RemoveFromTail()
    {
        var circularLinkedList = new CircularLinkedList<int>([1, 2, 3]);
        
        circularLinkedList.RemoveFromTail();
        
        Assert.Equal(2, circularLinkedList.Tail?.Data);
    }

    [Fact]
    public void RemoveFromTailInOneElementList()
    {
        var circularLinkedList = new CircularLinkedList<int>(1);
        
        circularLinkedList.RemoveFromTail();
        
        Assert.Null(circularLinkedList.Head?.Data);
    }
    
    [Fact]
    public void Remove()
    {
        var circularLinkedList = new CircularLinkedList<int>([1, 2, 3, 4, 5]);
        
        circularLinkedList.Remove(3);

        int[] result = [1, 2, 4, 5];
        Assert.Equal(4, circularLinkedList.Count);
        CollectionEquals(result, circularLinkedList);
    }
}