using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Transform[] _holster;
    private int _activeWeaponSlot;
    public void SetWeapon(Transform newWeapon, int bullets)
    {
        PlayerController playerController = GetComponent<PlayerController>();

        if (playerController.WeaponNow != null)
        {

            for (int i = 0; i <= _holster.Length - 1; i++)
            {
                _activeWeaponSlot = i;

                WeaponVar currentWeapon = _holster[i].GetComponentInChildren<WeaponVar>(true);

                if (currentWeapon != null)
                {
                    if ((int)newWeapon.GetComponent<WeaponVar>().WeaponTypeC == (int)currentWeapon.WeaponTypeC)
                    {
                        if (!currentWeapon.gameObject.activeSelf)
                        {
                            playerController.WeaponNow.DestroyCurrentWepon();

                            currentWeapon.gameObject.SetActive(true);
                            playerController.SetActiveWeapon(currentWeapon.gameObject.transform);

                            currentWeapon.AddBullets(bullets);

                        }
                        else
                        {
                            currentWeapon.AddBullets(bullets);
                            Debug.Log("f23gg");
                        }
                    }
                    else
                    {
                        Debug.Log("No match");
                    }

                }
                else
                {
                    if ((int)newWeapon.GetComponent<WeaponVar>().WeaponTypeC == _activeWeaponSlot)
                    {
                        Transform WeaponTransform = Instantiate(newWeapon, _holster[i].position, _holster[i].rotation);
                        WeaponTransform.transform.parent = _holster[i].transform;
                        playerController.SetActiveWeapon(WeaponTransform);

                    }
                }


            }

        }
        else
        {
            int k = (int)newWeapon.GetComponent<WeaponVar>().WeaponTypeC;
            Transform WeaponTransform = Instantiate(newWeapon, _holster[k].position, _holster[k].rotation);
            WeaponTransform.transform.parent = _holster[k].transform;
            playerController.SetActiveWeapon(WeaponTransform);
            return;
        }

    }

    public void ChangeWeapon(int weaponType)
    {
        PlayerController playerController = GetComponent<PlayerController>();

        WeaponVar currentWeapon = _holster[weaponType].GetComponentInChildren<WeaponVar>(true);

        if (currentWeapon != null)
        {
            playerController.WeaponNow.DestroyCurrentWepon();

            currentWeapon.gameObject.SetActive(true);
            playerController.SetActiveWeapon(currentWeapon.gameObject.transform);
        }
    }
}





