using UnityEngine;
using UnityEngine.Events;

public class GameInitializer : MonoBehaviour
{
    public UnityEvent<Component, System.Object> OnGameStarted;

    void Awake()
    {
        OnGameStarted.Invoke(this, null);
    }
}
