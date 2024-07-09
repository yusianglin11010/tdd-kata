using Xunit;

namespace RecentlyUsedList;

public class RecentlyUsedListTests
{
    private readonly RecentlyUsedList _recentlyUsedList = new RecentlyUsedList();
    private const string First = "first";
    private const string Second = "second";
    private const string Last = "last";
    
    [Fact]
    public void RecentlyAddFirst()
    {
        _recentlyUsedList.AddItem(First);
        _recentlyUsedList.AddItem(Second);
        _recentlyUsedList.AddItem(Last);
        
        Assert.Equal(Last, _recentlyUsedList.First());
        Assert.Equal(First, _recentlyUsedList.Last());
    }

    [Fact]
    public void RetrieveDataWithIndex()
    {
        _recentlyUsedList.AddItem(First);
        _recentlyUsedList.AddItem(Second);
        _recentlyUsedList.AddItem(Last);
        
        Assert.Equal(Last, _recentlyUsedList[0]);
        Assert.Equal(Second, _recentlyUsedList[1]);
        Assert.Equal(First, _recentlyUsedList[2]);
    }
    
    [Fact]
    public void DuplicateAdd()
    {
        _recentlyUsedList.AddItem(First);
        _recentlyUsedList.AddItem(Second);
        _recentlyUsedList.AddItem(Last);
        _recentlyUsedList.AddItem(Second);

        
        Assert.Equal(Second, _recentlyUsedList[0]);
        Assert.Equal(Last, _recentlyUsedList[1]);
        Assert.Equal(First, _recentlyUsedList[2]);
    }

    [Fact]
    public void InitializedAsEmpty()
    {
        var recentlyUsedList = new RecentlyUsedList();
        Assert.Empty(recentlyUsedList);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void AssertNullOrEmptyString(string item)
    {
        Assert.Throws<InvalidOperationException>(() => _recentlyUsedList.AddItem(item));
    }
    
    [Fact]
    public void SizeLimit()
    {
        const int maxSize = 1;
        var recentlyUsedList = new RecentlyUsedList(maxSize);
        var existedItem = "0";
        recentlyUsedList.AddItem(existedItem);
        var addedItem = "123";
        recentlyUsedList.AddItem(addedItem);
        
        Assert.Equal(maxSize, recentlyUsedList.Length());
        Assert.Equal(recentlyUsedList.First(), addedItem);
    }
    
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void OutOfRangeIndex(int index)
    {
        _recentlyUsedList.AddItem(First);
        _recentlyUsedList.AddItem(Second);

        Assert.Throws<IndexOutOfRangeException>(() => _recentlyUsedList[index]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void NotAllowedNegativeIndex(int index)
    {
        _recentlyUsedList.AddItem(First);
        _recentlyUsedList.AddItem(Second);

        Assert.Throws<ArgumentException>(() => _recentlyUsedList[index]);
    }
    
    [Fact]
    public void DefaultSizeLimitToFive()
    {
        var recentlyUsedList = new RecentlyUsedList();
        for (var i = 0; i < 5; i++)
        {
            recentlyUsedList.AddItem(i.ToString());
        }
        
        recentlyUsedList.AddItem(Last);
        Assert.Equal(5, recentlyUsedList.GetSize());
        Assert.Equal(Last, recentlyUsedList.First());
    }
}