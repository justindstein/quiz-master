using System.Collections.Generic;

/// <summary>
/// Extensions to the IList class
/// </summary>
public static class IListExtensions
{
    /// <summary>
    /// Randomly shuffle a list of elements using modified version of Fisher-Yates Shuffle algorithm
    /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static IList<T> Shuffle<T>(this IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = ThreadSafeRandom.ThisThreadsRandom.Next(i + 1);
            T temp = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = temp;
        }
        return list;
    }

    /// <summary>
    /// Insert element t in a random index
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="element"></param>
    /// <returns>The index of the randomly inserted element</returns>
    public static int RandomInsert<T>(this IList<T> list, T element)
    {
        int randomIndex = ThreadSafeRandom.ThisThreadsRandom.Next(list.Count + 1);
        list.Insert(randomIndex, element);
        return randomIndex;
    }

    /// <summary>
    /// Adds collection of elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="elements"></param>
    /// <returns>A chain reference to the affected IList</returns>
    public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> elements)
    {
        foreach (var element in elements)
        {
            list.Add(element);
        }
        return list;
    }

    /// <summary>
    /// Converts to Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns>A new Queue</returns>
    public static Queue<T> ToQueue<T>(this IList<T> list)
    {
        Queue<T> queue = new Queue<T>();
        foreach (var element in list)
        {
            queue.Enqueue(element);
        }
        return queue;
    }
}

