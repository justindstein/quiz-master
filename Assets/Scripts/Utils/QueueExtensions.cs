using System.Collections.Generic;

public static class QueueExtensions
{
    public static Queue<T> AddRange<T>(this Queue<T> queue, IEnumerable<T> elements)
    {
        foreach(T element in elements)
        {
            queue.Enqueue(element);
        }

        return queue;
    }
}
