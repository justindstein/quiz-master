﻿using System.Collections.Generic;

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
    public static IList<T> Shuffle<T>(this IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = ThreadSafeRandom.ThisThreadsRandom.Next(i);
            T temp = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = temp;
        }
        return list;
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

