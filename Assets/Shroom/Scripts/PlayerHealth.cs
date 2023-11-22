using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerHealth : MonoBehaviour, IDamagable, IHealing
{
    private HealthSystem _healthSystem;

    [SerializeField] [Range(0, 100)] private float _maxHealth;
    [SerializeField] private Image _hpBar;
    [SerializeField] private GameObject _getDamagePanel;
    [SerializeField] [Range(0, 0.5f)] private float _damagePanelTimer;

    public UnityEvent DeathEvent;
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
        // Debug.Log(name + "Dead");
    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        //Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
        SoundManager.PlaySound(SoundManager.Sound.PlayerDamaged);
        StartCoroutine(DamagePanel());

    }
    private void HealthSystem_OnHealed(object sender, EventArgs e)
    {
        // Debug.Log(name + "Healed");
    }

    private void Die()
    {
        _getDamagePanel.SetActive(false);
        OnDied?.Invoke();
        DeathEvent?.Invoke();
    }

    public void Heal(float heal)
    {
        _healthSystem.Heal(heal);
    }

    private IEnumerator DamagePanel()
    {
        _getDamagePanel.SetActive(true);
        yield return new WaitForSeconds(_damagePanelTimer);
        _getDamagePanel.SetActive(false);
    }
}
