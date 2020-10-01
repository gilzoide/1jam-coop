using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UISelectEvent : MonoBehaviour, ISelectHandler
{
    public UnityEvent selectHandler;

    public void OnSelect(BaseEventData eventData)
    {
        selectHandler.Invoke();
    }
}
