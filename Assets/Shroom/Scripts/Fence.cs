using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fence : MonoBehaviour, IDamagable
{
    private HealthSystem _healthSystem;

    [SerializeField] private float _maxHealth;
    private void Awake()
    {
        _healthSystem = new(_maxHealth);
        _healthSystem.OnDead += HealthSystem_OnDead;
        _healthSystem.OnDamaged += HealthSystem_OnDamaged;


    }
    public void Damage(float damage)
    {
        _healthSystem.Damage(damage);

    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        Die();

    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
    }

    private void Die()
    {
        _healthSystem.OnDead -= HealthSystem_OnDead;
        _healthSystem.OnDamaged -= HealthSystem_OnDamaged;

        Destroy(gameObject);

    }

}
