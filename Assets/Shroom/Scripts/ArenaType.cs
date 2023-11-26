using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArenaType : MonoBehaviour
{
    public static Action OnFirstArena;
    public static Action OnSecondArena;
    public static Action OnThirdArena;
    public static Action OnFourthArena;
    public static Action OnFifthArena;
    public static Action OnSantaArena;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArenaOne"))
        {
            Debug.Log("Spawn is true First");
            OnFirstArena?.Invoke();
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("ArenaTwo"))
        {
            OnSecondArena?.Invoke();
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("ArenaThree"))
        {
            OnThirdArena?.Invoke(); 
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("ArenaFour"))
        {
            OnFourthArena?.Invoke();
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("ArenaFive"))
        {
            OnFifthArena?.Invoke();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("SantaArena"))
        {
            OnSantaArena?.Invoke();
            other.gameObject.SetActive(false);
        }
    }

}
