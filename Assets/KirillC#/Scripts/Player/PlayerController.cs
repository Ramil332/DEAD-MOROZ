using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private GameObject _bombPref;
    [SerializeField] private float _bombForce = 20f;
    [SerializeField] private Transform _bombPosition;

    private Weapon _curentWeapon;
 //   private int _currentHealth;
    private Animator _animator;
   // private bool _isDied = false;
    public Weapon CurrentWeapon => _curentWeapon;

    private WeaponVar _weaponVar;

    public WeaponVar WeaponNow => _weaponVar;
   // public bool IsDied => _isDied;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        if(_weapons.Count >0)
        _curentWeapon = _weapons[0];
      //  _currentHealth = _health;
    }

    public void SetCurrentWeapon(Weapon currentWeapon)
    {
        _curentWeapon = currentWeapon;
    }

    public void SetActiveWeapon(WeaponVar weaponVar)
    {
        _weaponVar = weaponVar;
        _animator.SetLayerWeight(1, 1);

    }

    public void MelleAttack()
    {
        _animator.SetTrigger("MelleAttack");
        SoundManager.PlaySound(SoundManager.Sound.MelleAttack, transform.position);
    }
    public void SpawnBomb()
    {
        _animator.SetTrigger("TrowGranade");
       
    }

    
    //public void ApplayDamage(int damage)
    //{
    //    _health -= damage;
    //    if (_health <= 0 && _isDied != true)
    //    {
    //        Debug.Log("Die");
    //        _animator.SetTrigger("Die");
    //        _isDied = true;
    //    }
    //}
}
