public class PriorityQueue
{
    private List<(string, int)> _queue = new List<(string, int)>();

    /// <summary>
    /// Adds an item to the back of the queue
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _queue.Add((value, priority));
    }

    /// <summary>
    /// Removes the item with the highest priority and returns its value.
    /// If there are more than one item with the highest priority, then the item
    /// closest to the front of the queue will be removed and its value returned.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new System.Exception("The queue is empty");
        }

        int highestPriority = _queue.Max(item => item.Item2);
        int indexToRemove = _queue.FindIndex(item => item.Item2 == highestPriority);

        string value = _queue[indexToRemove].Item1;
        _queue.RemoveAt(indexToRemove);
        return value;
    }

    public override string ToString()
    {
        return string.Join(", ", _queue.Select(item => $"({item.Item1}, {item.Item2})"));
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}