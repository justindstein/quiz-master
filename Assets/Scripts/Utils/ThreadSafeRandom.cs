﻿using System;
using System.Threading;

/// <summary>
/// https://stackoverflow.com/questions/273313/randomize-a-listt
/// </summary>
public static class ThreadSafeRandom
{
    [ThreadStatic] private static System.Random Local;

    public static Random ThisThreadsRandom
    {
        get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
    }
}
