using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SantaHealth : MonoBehaviour, IDamagable
{
    private HealthSystem _healthSystem;

    [SerializeField] [Range(0, 1000)] private float _maxHealth;
    [SerializeField] [Range(0, 10000)] private float _explosionForce = 1000f;
    private Image _hpBar;
    /*[Header("Ёффекты при смерти")]
    [SerializeField] private Transform _vxfExplosionDie;
    [SerializeField] private Transform _pfSnowmanParts;
    [SerializeField] private Transform _spawnVFXPoint;*/

    private Animator _santaAnimator;
    private bool _died = false;
    public static Action OnSantaDied;
    public bool Died => _died;

    private void Awake()
    {
        _santaAnimator = GetComponent<Animator>();
        _healthSystem = new(_maxHealth);
        _healthSystem.OnDead += HealthSystem_OnDead;
        _healthSystem.OnDamaged += HealthSystem_OnDamaged;
        _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        // _healthSystem.OnHealed += HealthSystem_OnHealed;
        _hpBar = GameObject.Find("HPBarSanta_Image").GetComponent<Image>();
        _hpBar.fillAmount = _healthSystem.GetHealthPercent();

    }

    public void Damage(float damage)
    {
        SoundManager.PlaySound(SoundManager.Sound.SantaHit);
        //  healthBar.gameObject.SetActive(true);
        //  direction = position;
        _healthSystem.Damage(damage);
       // DamagePopup.Create(transform.position, (int)damage, false);

        // healthBar.SetHealthBarPercentage(healthSystem.GetHealth() / healthMax);

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
        Instantiate(GameAssets.I.PfDamageParticles, transform.position, Quaternion.identity);

        // Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
    }
    //private void HealthSystem_OnHealed(object sender, EventArgs e)
    //{
    //    Debug.Log(name + "Healed");
    //}

    private void Die()
    {
        _died = true;
        OnSantaDied?.Invoke();
        _healthSystem.OnDead -= HealthSystem_OnDead;
        _healthSystem.OnDamaged -= HealthSystem_OnDamaged;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 1000f);

       /* foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy") && collider != null)
            {
                IDamagable damagable = collider.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.Damage(1000f);
                }
            }


           

        }*/
        _santaAnimator.SetTrigger("Die");
        this.GetComponent<EnemyMovement>().enabled = false;
        this.GetComponent<SantaBossController>().enabled = false;

        PlayerUI playerUI = GameObject.Find("Player").GetComponent<PlayerUI>();
        playerUI.WinGame();

    }
}
