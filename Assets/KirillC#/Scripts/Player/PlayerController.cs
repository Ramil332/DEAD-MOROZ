using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private GameObject _bombPref;
    [SerializeField] private float _bombForce = 20f;

    private Weapon _curentWeapon;
    private int _currentHealth;
    private Animator _animator;

    public Weapon CurrentWeapon => _curentWeapon;

    

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _curentWeapon = _weapons[0];
        _currentHealth = _health;
    }

    public void SetCurrentWeapon(Weapon currentWeapon)
    {
        _curentWeapon = currentWeapon;
    }

    public void MelleAttack()
    {
        Debug.Log("MelleAttack");
        _animator.SetTrigger("MelleAttack");
    }
    public void SpawnBomb()
    {
       GameObject bomb = Instantiate(_bombPref, transform.position, Quaternion.identity);
       // bomb.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * _bombForce, ForceMode.Impulse);
    }

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Debug.Log("Die");
            Destroy(gameObject);
        }
    }
}
