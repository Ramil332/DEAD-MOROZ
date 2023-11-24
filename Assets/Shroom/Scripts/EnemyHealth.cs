using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    private HealthSystem _healthSystem;

    [SerializeField] private Transform[] _drop;
    [SerializeField] [Range(0, 100)] private float _maxHealth;
    [SerializeField] [Range(0, 10000)] private float _explosionForce = 1000f;
    [SerializeField] [Range(0, 100)] private float _dropChance = 20f;

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
        DamagePopup.Create(transform.position, (int)damage, false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Damage(1000);
        }
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        Die();
       // Debug.Log(name + "Dead");

    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        // Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
        SoundManager.PlaySound(SoundManager.Sound.EnemyHit);
        Instantiate(GameAssets.I.PfDamageParticles, transform.position, Quaternion.identity);
    }
    //private void HealthSystem_OnHealed(object sender, EventArgs e)
    //{
    //    Debug.Log(name + "Healed");
    //}

    private void Die()
    {

        bool IsSpawne = UnityEngine.Random.Range(0, 100) < _dropChance;

        if (IsSpawne)
        {
            if (_drop != null)
            {
                int dropSpawn = UnityEngine.Random.Range(0, _drop.Length);
                Instantiate(_drop[dropSpawn], transform.position, Quaternion.identity);
            }
        }

      //  SoundManager.PlaySound(SoundManager.Sound.EnemyDie);
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
