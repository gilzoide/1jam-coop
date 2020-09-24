using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public float activationDelay = 0f;
    public UnityEvent onActivate;
    public UnityEvent onActivateWaitingDelay;
    public UnityEvent onActivateDelayEnded;

    private bool mayBeActivated = true;

    public void Activate()
    {
        if (mayBeActivated)
        {
            onActivate.Invoke();
            if (activationDelay > 0f)
            {
                StartCoroutine(DelayTask());
            }
        }
    }

    private IEnumerator DelayTask()
    {
        mayBeActivated = false;
        onActivateWaitingDelay.Invoke();
        yield return new WaitForSeconds(activationDelay);
        mayBeActivated = true;
        onActivateDelayEnded.Invoke();
    }
}
