using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Animator _animatorPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            _animatorPlayer.SetLayerWeight(1, 1);
            other.gameObject.GetComponent<PlayerController>().SetCurrentWeapon(_weapon);
            _weapon.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
