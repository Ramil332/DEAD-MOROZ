using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Transform _holster;
    public void SetWeapon(Transform newWeapon)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        if (_holster != null)
        {
            WeaponVar weaponCurrent = _holster.GetComponentInChildren<WeaponVar>();
            if (weaponCurrent != null)
            {
                weaponCurrent.DestroyCurrentWepon();
                Transform WeaponTransform = Instantiate(newWeapon, _holster.position, _holster.rotation);
                WeaponTransform.transform.parent = _holster.transform;
                playerController.SetActiveWeapon(WeaponTransform);

            }
            else
            {

                Transform WeaponTransform = Instantiate(newWeapon, _holster.position, _holster.rotation);
                WeaponTransform.transform.parent = _holster.transform;
                playerController.SetActiveWeapon(WeaponTransform);
            }
        }
        //foreach (WeaponVar exWeapon in Resources.FindObjectsOfTypeAll(typeof(WeaponVar)) as WeaponVar[])
        //{
        //    if (newWeapon.WeaponTypeC == exWeapon.WeaponTypeC)
        //    {
        //        playerController.SetActiveWeapon(exWeapon);

        //        exWeapon.gameObject.SetActive(true);
        //       // exWeapon.WeaponPanel.SetActive(true);
        //    }

        //    if (newWeapon.WeaponTypeC != exWeapon.WeaponTypeC)
        //    {

        //        exWeapon.gameObject.SetActive(false);
        //       // exWeapon.WeaponPanel.SetActive(false);

        //    }
        //}
    }
}
