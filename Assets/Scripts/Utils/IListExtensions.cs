using System.Collections.Generic;

/// <summary>
/// Extensions to the IList class
/// </summary>
public static class IListExtensions
{
    /// <summary>
    /// Randomly shuffle a list of elements using Fisher-Yates Shuffle algorithm.
    /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = ThreadSafeRandom.ThisThreadsRandom.Next(i);
            T temp = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = temp;
        }
    }

    /// <summary>
    /// Randomly shuffle elements of a list in O(n) runtime.
    /// https://stackoverflow.com/questions/273313/randomize-a-listt
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void OldShuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    /// <summary>
    /// Insert element t in a random index.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="t"></param>
    /// <returns>The index of the randomly inserted element</returns>
    public static int RandomInsert<T>(this IList<T> list, T t)
    {
        int randomIndex = ThreadSafeRandom.ThisThreadsRandom.Next(list.Count - 1);
        list.Insert(randomIndex, t);
        return randomIndex;
    }
}

