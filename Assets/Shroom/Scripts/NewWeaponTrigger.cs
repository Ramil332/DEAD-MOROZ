using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeaponTrigger : MonoBehaviour
{
    [SerializeField] private Transform _weaponVar;
    ActiveWeapon _activeWeapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SoundManager.PlaySound(SoundManager.Sound.GiveWeapon, transform.position);
            _activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();

           // WeaponVar weaponVar = _weaponVar.GetComponent<WeaponVar>();
            //if (weaponVar != null)
            _activeWeapon.SetWeapon(_weaponVar);
            Destroy(gameObject);
        }
    }
}
