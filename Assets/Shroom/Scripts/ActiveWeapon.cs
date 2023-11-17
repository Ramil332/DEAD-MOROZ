using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public void SetWeapon(WeaponVar newWeapon)
    {
        PlayerController playerController = GetComponent<PlayerController>();

        foreach (WeaponVar exWeapon in Resources.FindObjectsOfTypeAll(typeof(WeaponVar)) as WeaponVar[])
        {
            if (newWeapon.WeaponTypeC == exWeapon.WeaponTypeC)
            {
                playerController.SetActiveWeapon(exWeapon);

                exWeapon.gameObject.SetActive(true);
               // exWeapon.WeaponPanel.SetActive(true);
            }

            if (newWeapon.WeaponTypeC != exWeapon.WeaponTypeC)
            {

                exWeapon.gameObject.SetActive(false);
               // exWeapon.WeaponPanel.SetActive(false);

            }
        }
    }
}
