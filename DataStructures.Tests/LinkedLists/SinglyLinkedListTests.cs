using DataStructures.LinkedLists;

namespace DataStructures.Tests.LinkedLists;

public class SinglyLinkedListTests
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
        var singlyLinkedList = new SinglyLinkedList<int>();

        Assert.True(singlyLinkedList.IsEmpty());
    }

    [Fact]
    public void Clear()
    {
        var singlyLinkedList = new SinglyLinkedList<int>([1, 2, 3, 4, 5]);
        
        singlyLinkedList.Clear();
        
        Assert.True(singlyLinkedList.IsEmpty());
    }
    
    [Fact]
    public void AddAtHead()
    {
        var singlyLinkedList = new SinglyLinkedList<int>(1);
        
        singlyLinkedList.AddAtHead(2);
        
        Assert.Equal(2, singlyLinkedList.Head?.Data);
    }
    
    [Fact]
    public void AddAtTail()
    {
        var singlyLinkedList = new SinglyLinkedList<int>(1);
        
        singlyLinkedList.AddAtTail(2);
        
        Assert.Equal(2, singlyLinkedList.Tail?.Data);
    }

    [Fact]
    public void InsertAfter()
    {
        var singlyLinkedList = new SinglyLinkedList<int>([1, 2]);
        
        singlyLinkedList.InsertAfter(1, 3);
        
        int[] resultArray = [1, 3, 2];

        CollectionEquals(resultArray, singlyLinkedList);
    }

    [Fact]
    public void InsertAfterInNullableValueList()
    {
        var nullableList = new SinglyLinkedList<int?>([1, null]);
        
        nullableList.InsertAfter(null, 3);
        
        int?[] resultNullableArray = [1, null, 3];
        CollectionEquals(resultNullableArray, nullableList);
    }
    
    [Fact]
    public void InsertBefore()
    {
        var singlyLinkedList = new SinglyLinkedList<int>([1, 2]);
        
        singlyLinkedList.InsertBefore(2, 3);

        int[] resultArray = [1, 3, 2];

        CollectionEquals(resultArray, singlyLinkedList);
    }

    [Fact]
    public void InsertBeforeInNullableValueList()
    {
        var nullableList = new SinglyLinkedList<int?>([1, null]);
        
        nullableList.InsertBefore(null, 3);
        
        int?[] resultNullableArray = [1, 3, null];
        CollectionEquals(resultNullableArray, nullableList);
    }
    
    [Fact]
    public void RemoveFromHead()
    {
        var singlyLinkedList = new SinglyLinkedList<int>([1, 2]);
        
        singlyLinkedList.RemoveFromHead();
        
        Assert.Equal(2, singlyLinkedList.Head?.Data);
    }

    [Fact]
    public void RemoveFromHeadInOneElementList()
    {
        var singlyLinkedList = new SinglyLinkedList<int>(1);
        
        singlyLinkedList.RemoveFromHead();
        
        Assert.Null(singlyLinkedList.Tail?.Data);
    }
    
    [Fact]
    public void RemoveFromTail()
    {
        var singlyLinkedList = new SinglyLinkedList<int>([1, 2]);
        
        singlyLinkedList.RemoveFromTail();
        
        Assert.Equal(1, singlyLinkedList.Tail?.Data);
    }

    [Fact]
    public void RemoveFromTailInOneElementList()
    {
        var singlyLinkedList = new SinglyLinkedList<int>(1);
        
        singlyLinkedList.RemoveFromTail();
        
        Assert.Null(singlyLinkedList.Head?.Data);
    }
    
    [Fact]
    public void Remove()
    {
        var singlyLinkedList = new SinglyLinkedList<int>([1, 2, 3, 4, 5]);
        
        singlyLinkedList.Remove(3);

        int[] result = [1, 2, 4, 5];
        Assert.Equal(4, singlyLinkedList.Count);
        CollectionEquals(result, singlyLinkedList);
    }
}