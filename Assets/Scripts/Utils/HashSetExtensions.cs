using System.Collections.Generic;

public static class HashSetExtensions
{
    public static T[] ToArray<T>(this HashSet<T> hashSet)
    {
        T[] array = new T[hashSet.Count];
        hashSet.CopyTo(array);
        return array;
    }
}
