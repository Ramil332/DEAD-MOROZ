using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Animator _animatorPlayer;
    

    [SerializeField] private GameObject _pistolTrigger;
    [SerializeField] private Transform _weaponTriggerSpawn;

    [SerializeField] private GameObject _miniganTrigger;

    private Weapon _currentWeapon;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            _animatorPlayer.SetLayerWeight(1, 1);
            if(other.gameObject.GetComponent<PlayerController>().CurrentWeapon != null)
            {
                if(other.gameObject.GetComponent<PlayerController>().CurrentWeapon.gameObject.GetComponent<Pistol>())
                {
                    Debug.Log("Pistol Trigger");
                    _pistolTrigger.SetActive(true);
                    _pistolTrigger.transform.position = _weaponTriggerSpawn.position;
                }
                if (other.gameObject.GetComponent<PlayerController>().CurrentWeapon.gameObject.GetComponent<Minigan>())
                {
                    Debug.Log("Minigasn Trigger");
                    _miniganTrigger.SetActive(true);
                    _miniganTrigger.transform.position = _weaponTriggerSpawn.position;
                }
                _currentWeapon = other.gameObject.GetComponent<PlayerController>().CurrentWeapon;
                _currentWeapon.gameObject.SetActive(false);
            }
            other.gameObject.GetComponent<PlayerController>().SetCurrentWeapon(_weapon);
            _weapon.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
