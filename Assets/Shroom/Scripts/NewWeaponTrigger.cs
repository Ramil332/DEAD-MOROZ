using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeaponTrigger : MonoBehaviour
{
    [SerializeField] private WeaponVar _weaponVar;
    ActiveWeapon _activeWeapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            _activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();

           // WeaponVar weaponVar = _weaponVar.GetComponent<WeaponVar>();
            _activeWeapon.SetWeapon(_weaponVar);
        }
    }
}
