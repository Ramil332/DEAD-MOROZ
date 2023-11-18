using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    private HealthSystem _healthSystem;

    [SerializeField] [Range(0, 100)] private float _maxHealth;
    [SerializeField] [Range(0, 10000)] private float _explosionForce = 1000f;

    [Header("Ёффекты при смерти")]
    [SerializeField] private Transform _vxfExplosionDie;
    [SerializeField] private Transform _pfSnowmanParts;
    [SerializeField] private Transform _spawnVFXPoint;

    private bool _died = false;

    public bool Died => _died;

    private void Awake()
    {
        _healthSystem = new(_maxHealth);
        _healthSystem.OnDead += HealthSystem_OnDead;
        _healthSystem.OnDamaged += HealthSystem_OnDamaged;
        // _healthSystem.OnHealed += HealthSystem_OnHealed;

    }

    public void Damage(float damage)
    {
        //  healthBar.gameObject.SetActive(true);
        //  direction = position;
        _healthSystem.Damage(damage);
        // healthBar.SetHealthBarPercentage(healthSystem.GetHealth() / healthMax);

    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        Die();
       // Debug.Log(name + "Dead");

    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
       // Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
    }
    //private void HealthSystem_OnHealed(object sender, EventArgs e)
    //{
    //    Debug.Log(name + "Healed");
    //}

    private void Die()
    {
        _died = true;
        _healthSystem.OnDead -= HealthSystem_OnDead;
        _healthSystem.OnDamaged -= HealthSystem_OnDamaged;

        Instantiate(_vxfExplosionDie, _spawnVFXPoint.position, Quaternion.identity);
        Transform SnowmanParts = Instantiate(_pfSnowmanParts, _spawnVFXPoint.position, transform.rotation);

        foreach (Transform child in SnowmanParts)
        {
            if (child.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody))
            {
                childRigidbody.AddExplosionForce(_explosionForce, transform.position, 5f);
            }
        }


        Destroy(gameObject);
    }
}
