using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    

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


}