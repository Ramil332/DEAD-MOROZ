using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour, IDamagable
{
    private HealthSystem _healthSystem;

    [SerializeField] [Range(0, 100)] private float _maxHealth;
    [SerializeField] private Image _hpBar;
    
    public static Action OnDied;

    private void Awake()
    {
        _healthSystem = new(_maxHealth);
        _healthSystem.OnDead += HealthSystem_OnDead;
        _healthSystem.OnDamaged += HealthSystem_OnDamaged;
        _healthSystem.OnHealed += HealthSystem_OnHealed;
        _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;

        _hpBar.fillAmount = _healthSystem.GetHealthPercent();

    }

    public void Damage(float damage)
    {
        //  healthBar.gameObject.SetActive(true);
        //  direction = position;
        _healthSystem.Damage(damage);
        // healthBar.SetHealthBarPercentage(healthSystem.GetHealth() / healthMax);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Damage(1000);
        }
    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        _hpBar.fillAmount = _healthSystem.GetHealthPercent();
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        Die();
        Debug.Log(name + "Dead");
    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
    }
    private void HealthSystem_OnHealed(object sender, EventArgs e)
    {
        Debug.Log(name + "Healed");
    }

    private void Die()
    {
        OnDied?.Invoke();
    }
}
