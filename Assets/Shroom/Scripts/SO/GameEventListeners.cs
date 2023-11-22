using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventListeners : MonoBehaviour
{
    public GameEvent Event;

    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListeners(this);
    }

    private void OnDisable()
    {
        Event.UnRegisterListeners(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
