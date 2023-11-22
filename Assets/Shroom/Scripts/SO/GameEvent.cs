using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvents", menuName = "ScriptableObjects/GameEvents", order = 2)]
public class GameEvent : ScriptableObject
{
    private List<GameEventListeners> _listeners = new();

    public void RegisterListeners(GameEventListeners listeners)
    {
        _listeners.Add(listeners);
    }

    public void UnRegisterListeners(GameEventListeners listeners)
    {
        _listeners.Remove(listeners);
    }
    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }
}
