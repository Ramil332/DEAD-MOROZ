using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fence : MonoBehaviour, IDamagable
{
    private HealthSystem _healthSystem;

    [SerializeField] private GameObject _armorSnow;

    [SerializeField] private float _maxHealth;

    private Animator _animator;
    private void Awake()
    {
        if (_armorSnow != null)
           _animator = _armorSnow.GetComponent<Animator>();

        _healthSystem = new(_maxHealth);
        _healthSystem.OnDead += HealthSystem_OnDead;
        _healthSystem.OnDamaged += HealthSystem_OnDamaged;


    }
    public void Damage(float damage)
    {
        _healthSystem.Damage(damage);
       // DamagePopup.Create(transform.position, (int)damage, false);

    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        if(_armorSnow != null)
        _animator.SetBool("ShildDestroy", true);

        Die();

    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        //Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
    }

    private void Die()
    {
        _healthSystem.OnDead -= HealthSystem_OnDead;
        _healthSystem.OnDamaged -= HealthSystem_OnDamaged;

        Destroy(gameObject);

    }

}
