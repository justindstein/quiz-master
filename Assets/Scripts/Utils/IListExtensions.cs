using System.Collections.Generic;

/// <summary>
/// Extensions to the IList class
/// https://stackoverflow.com/questions/273313/randomize-a-listt
/// </summary>
public static class IListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
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
}

