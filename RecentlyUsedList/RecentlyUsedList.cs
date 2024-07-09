namespace RecentlyUsedList;

public class RecentlyUsedList : List<string>
{
    private List<string> Values { get; } = [];
    private ISet<string> UniqueSet { get; } = new HashSet<string>();

    private readonly int _maxSize;
    
    public RecentlyUsedList(int maxSize = 5)
    {
        _maxSize = maxSize;
    }
    
    public new object this[int i]
    {
        get
        {
            if (i >= Length())
            {
                throw new IndexOutOfRangeException($"Index {i} is out of range");
            }

            if (i < 0)
            {
                throw new ArgumentException("Negative index is not allowed");
            }
            
            return i < 0
                // -1 -> 0 = -(-1) -1
                // -2 -> 1 = -(-2) - 1
                // -3 -> 2 = -(-3) - 1
                ? Values[-i - 1]
                : Values[Values.Count - i - 1];
        }
    }

    public int GetSize()
    {
        return _maxSize;
    }
    
    public string? First()
    {
        return Values.ElementAtOrDefault(Length() - 1);
    }

    public string? Last()
    {
        return Values.ElementAtOrDefault(0);
    }

    public void AddItem(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new InvalidOperationException(nameof(input));
        }
        
        if (UniqueSet.Contains(input))
        {
            Values.Remove(input);
        }
        else
        {
            UniqueSet.Add(input);
        }
        
        EnsureEnoughCapacity();
        Values.Add(input);
    }

    public int Length()
    {
        return Values.Count;
    }

    private void EnsureEnoughCapacity()
    {
        if (Values.Count >= _maxSize)
        {
            Values.Remove(Last());
        }
    }
}