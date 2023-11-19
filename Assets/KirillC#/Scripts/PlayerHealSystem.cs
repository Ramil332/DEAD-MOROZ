using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealSystem : MonoBehaviour
{
    [SerializeField][Range(0, 100)] float _healAmount;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();

    }

    private void OnTriggerEnter(Collider other)
    {             
        if (other.CompareTag("Player"))
        {
            IHealing heal = other.GetComponent<IHealing>();
            if (heal != null)
            {
                Debug.Log("Heal Player");
                heal.Heal(_healAmount);
                Destroy(gameObject);
            }
        }
    }
}

