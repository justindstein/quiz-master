using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

    public void Raise()
    {
        Raise(null, null);
    }

    public void Raise(Component component)
    {
        Raise(component, null);
    }

    public void Raise(System.Object obj)
    {
        Raise(null, obj);
    }

    public void Raise(Component component, System.Object obj)
    {
        Debug.Log(string.Format("{0}.Raise() [component {1}] [object {2}]", this.name, component, obj));
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(component, obj);
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
