using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponVar : MonoBehaviour
{
    public enum WeaponType { pistol, shotgun, minigun, }

    public WeaponVar.WeaponType WeaponTypeC;

    [SerializeField] private WeaponSO _weaponStats;
    [SerializeField] private Transform _pfbullet;
    public UnityEvent ShootEvent;
    private bool _isShooting, _isReloading;
    private float _attackTime;
    private int _bulletsInMagazine;

    private void OnEnable()
    {
        _bulletsInMagazine = _weaponStats.ClipSize;
    }
    public int BulletsInMagazine => _bulletsInMagazine;
    public void Shoot(Transform shootPoint)
    {

        if (_isShooting && !_isReloading)
        {
            if (_bulletsInMagazine > 0)
            {
                switch (WeaponTypeC)
                {
                    case WeaponType.pistol:
                        SoundManager.PlaySound(SoundManager.Sound.ShootPistol);

                        break;

                    case WeaponType.minigun:
                        SoundManager.PlaySound(SoundManager.Sound.ShootMinigan);

                        break;

                    default:
                        Debug.Log("NOTHING");
                        break;


                }

                Instantiate(_weaponStats.Bullet, shootPoint.position, shootPoint.rotation);
                _bulletsInMagazine--;
                ShootEvent?.Invoke();
            }
            else
            {
                StartCoroutine(Reload());
            }


        }
    }
    private IEnumerator Reload()
    {
        Debug.Log(_bulletsInMagazine);
        _isReloading = true;
        yield return new WaitForSeconds(_weaponStats.ReloadTime);
        _bulletsInMagazine = _weaponStats.ClipSize;
        _isReloading = false;
        Debug.Log(_bulletsInMagazine);

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

    public void DestroyCurrentWepon()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        UpdateShooting(Time.time);

    }
}
