using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ParameterizedUnityEvent : UnityEvent<Component, System.Object> { }

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public ParameterizedUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Component component, System.Object obj)
    {
        Response.Invoke(component, obj);
    }
}