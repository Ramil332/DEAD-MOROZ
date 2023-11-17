using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVar : MonoBehaviour
{
    public enum WeaponType { pistol, shotgun, minigun, }

    public WeaponVar.WeaponType WeaponTypeC;

    [SerializeField] private WeaponSO _weaponStats;
    [SerializeField] private Transform _shootPoint;
    //public GameObject WeaponPanel;

    private Animator _animatorPlayer;

    private void OnEnable()
    {
        _animatorPlayer = GameObject.Find("Player").GetComponentInChildren<Animator>();
    }

    private bool _isAttacking;
    private float _attackTime;


    public void Shoot()
    {
        if (_weaponStats.FireRate <= _attackTime)
        {
            Instantiate(_weaponStats.Bullet, _shootPoint.position, _shootPoint.rotation);
            _animatorPlayer.SetTrigger("Fire");
            _attackTime = 0;

        }
        //if (_isAttacking)
        //{
        //    Instantiate(_weaponStats.Bullet, _shootPoint.position, _shootPoint.rotation);
        //    _weaponStats.AnimatorPlayer.SetTrigger("Fire");

        //}
    }

    //private void UpdateShooting(float deltaTime)
    //{
    //    float fireInterval = 1.0f / _weaponStats.FireRate;


    //    if (deltaTime > _attackTime)
    //    {

    //        _isAttacking = true;

    //        _attackTime = deltaTime + fireInterval;
    //    }
    //    else
    //    {
    //        _isAttacking = false;
    //    }
    //}

    private void Update()
    {
        //UpdateShooting(Time.time);

        _attackTime += Time.deltaTime;

      
    }
}
