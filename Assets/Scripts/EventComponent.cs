using UnityEngine;
using UnityEngine.Events;

public class EventComponent : MonoBehaviour
{
    public UnityEvent onEvent;

    public void InvokeEvent()
    {
        onEvent.Invoke();
    }
}
