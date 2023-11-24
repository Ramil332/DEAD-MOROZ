using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealSystem : MonoBehaviour
{
    [SerializeField][Range(0, 100)] float _healAmount;
    [SerializeField][Range(0, 100)] float _deleteTime = 5f;

    private void OnEnable()
    {

        Destroy(gameObject, _deleteTime);
    }

    private void OnTriggerEnter(Collider other)
    {             
        if (other.CompareTag("Player"))
        {
            IHealing heal = other.GetComponent<IHealing>();
            if (heal != null)
            {
                SoundManager.PlaySound(SoundManager.Sound.IceCream);
                DamagePopup.Create(transform.position, (int)_healAmount, true);
                heal.Heal(_healAmount);
                Destroy(gameObject);
            }
        }
    }
}

