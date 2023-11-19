using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVar : MonoBehaviour
{
    public enum WeaponType { pistol, shotgun, minigun, }

    public WeaponVar.WeaponType WeaponTypeC;

    [SerializeField] private WeaponSO _weaponStats;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _pfbullet; 

    //public GameObject WeaponPanel;

    public Animator _animatorPlayer;
    private bool _isReloading, _isShooting;
    private float _attackTime;


    private void Awake()
    {
       _animatorPlayer = GameObject.Find("Player").GetComponentInChildren<Animator>();
    }

    public void Shoot()
    {
        //if (_weaponStats.FireRate <= _attackTime)
        //{
        //    Instantiate(_weaponStats.Bullet, _shootPoint.position, _shootPoint.rotation);
        //    _animatorPlayer.SetTrigger("Fire");
        //    _attackTime = 0;

        //}
            TEste();
        if (!_isReloading)
        {
            SoundManager.PlaySound(SoundManager.Sound.Shoot, transform.position);
            Instantiate(_weaponStats.Bullet, _shootPoint.position, _shootPoint.rotation);
            _animatorPlayer.SetTrigger("Fire");
            _attackTime = 0;


        //if (_isAttacking)
        //{
        //    Instantiate(_weaponStats.Bullet, _shootPoint.position, _shootPoint.rotation);
        //    _weaponStats.AnimatorPlayer.SetTrigger("Fire");

        //}
    }

    void TEste()
    {
        Instantiate(_pfbullet, _shootPoint.position, _shootPoint.rotation);
        Debug.Log("Adgg;");
    }
    private void UpdateShooting()
    {
        _attackTime += Time.deltaTime;

        if (_weaponStats.FireRate <= _attackTime)
        {

            _isReloading = false;

            _attackTime = 0;
        }

    }



    private void Update()
    {
        UpdateShooting();

        if (_isShooting)
        {

        }

    }
}
