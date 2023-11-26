using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponVar : MonoBehaviour
{
    public enum WeaponType {shotgun, minigun, }

    public WeaponVar.WeaponType WeaponTypeC;

    [SerializeField] private WeaponSO _weaponStats;
    // [SerializeField] private Transform _pfbullet;
    public UnityEvent ShootEvent;
    private bool _isShooting, _isReloading;
    private float _attackTime;
    private int _bulletsInMagazine;
    public int BulletsTotalAmount;

    private void Awake()
    {
        _bulletsInMagazine = _weaponStats.ClipSize;

        switch (WeaponTypeC)
        {
            case WeaponType.minigun:
                BulletsTotalAmount = 100;

                break;

            case WeaponType.shotgun:
                BulletsTotalAmount = 24;

                break;

            default:
                Debug.Log("NOTHING");
                break;

        }
    }

    private void OnEnable()
    {
        if (!_isReloading && _isShooting && BulletsTotalAmount > 0 && BulletsInMagazine < 1)
        {
            StartCoroutine(Reload());
        }

    }

    public int BulletsInMagazine
    {
        get
        {
            return _bulletsInMagazine;
        }
        set
        {
            _bulletsInMagazine = value;
        }
    }
    public void Shoot(Transform shootPoint, Vector3 target)
    {
        if (_isShooting && !_isReloading)
        {
            if (BulletsInMagazine > 0)
            {
                switch (WeaponTypeC)
                {

                    case WeaponType.minigun:
                        SoundManager.PlaySound(SoundManager.Sound.ShootMinigan);
                        Bullet bullet = Instantiate(_weaponStats.Bullet, shootPoint.position, shootPoint.rotation);
                        bullet.SetDestination(target);
                        Instantiate(_weaponStats.MuzzleEffect, shootPoint.position, shootPoint.rotation);

                        break;

                    case WeaponType.shotgun:
                        SoundManager.PlaySound(SoundManager.Sound.ShootPistol);
                        for (float i = -1f; i < 2; i += 1f)
                        {
                            Bullet bulletShotgun = Instantiate(_weaponStats.Bullet, new Vector3(shootPoint.position.x, shootPoint.position.y, shootPoint.position.z + (i * 0.5f)),
                            Quaternion.Euler(shootPoint.rotation.x, shootPoint.rotation.y + (i * 10f), shootPoint.rotation.z));

                            bulletShotgun.SetDestination(new Vector3(target.x + (i * 1.5f), target.y, target.z + (i * 1.5f)));
                            Debug.Log("Ûðùå Åôêïó " + bulletShotgun.gameObject.name);

                            Instantiate(_weaponStats.MuzzleEffect, new Vector3(shootPoint.position.x, shootPoint.position.y, shootPoint.position.z + (i * 0.5f)),
                            Quaternion.Euler(shootPoint.rotation.x, shootPoint.rotation.y - (i * 10f), shootPoint.rotation.z));


                        }
                      

                        break;

                    default:
                        Debug.Log("NOTHING");
                        break;


                }

               /* Bullet bullet = Instantiate(_weaponStats.Bullet, shootPoint.position, shootPoint.rotation);
                bullet.SetDestination(target);
                Instantiate(_weaponStats.MuzzleEffect, shootPoint.position, shootPoint.rotation);*/
                BulletsInMagazine--;
                ShootEvent?.Invoke();
            }
            else
            {
                if (BulletsTotalAmount > 0) StartCoroutine(Reload());
            }


        }
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        SoundManager.PlaySound(SoundManager.Sound.WeaponReaload);
        yield return new WaitForSeconds(_weaponStats.ReloadTime);

        if (BulletsTotalAmount > _weaponStats.ClipSize)
        {
            BulletsInMagazine = _weaponStats.ClipSize;
            BulletsTotalAmount -= _weaponStats.ClipSize;

        }
        else
        {
            BulletsInMagazine = BulletsTotalAmount;
            BulletsTotalAmount = 0;
        }

        _isReloading = false;
    }

    private void UpdateShooting(float deltaTime)
    {

        float fireInterval = 1.0f / _weaponStats.FireRate;

        if (deltaTime > _attackTime)
        {
            _isShooting = true;
            _attackTime = deltaTime + fireInterval;
        }
        else
        {
            _isShooting = false;
        }

    }

    public void AddBullets(int bullets)
    {
        BulletsTotalAmount += bullets;
    }

    public void DestroyCurrentWepon()
    {
        StopCoroutine(Reload());
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void SetCurrentWeapon()
    {
        gameObject.SetActive(true);
        if (!_isReloading && _isShooting && BulletsTotalAmount > 0 && BulletsInMagazine < 1)
        {
            StartCoroutine(Reload());
        }
    }

    private void Update()
    {
        UpdateShooting(Time.time);
        if (!_isReloading && _isShooting && BulletsTotalAmount > 0 && BulletsInMagazine < 1)
        {
            StartCoroutine(Reload());
        }

    }
}
