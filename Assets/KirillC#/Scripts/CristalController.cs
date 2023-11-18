using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CristalController : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject[] _pfEnemy;
    [SerializeField] private int  _enemyAmount;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private GameObject _vfxVortex;

    private HealthSystem _healthSystem;

    [SerializeField] [Range(0, 1000)] private float _maxHealth;

    public static Action OnCrystalDestroyed;


    [SerializeField] private Transform[] _spawnPoints;
    private List<GameObject> _currentEnemys = new List<GameObject>();
    private float _currentTimeSpawner = 0f;
    public List<GameObject> CurrentEnemys => _currentEnemys;

    private void Awake()
    {
        _healthSystem = new(_maxHealth);
        _healthSystem.OnDead += HealthSystem_OnDead;
        _healthSystem.OnDamaged += HealthSystem_OnDamaged;
        _healthSystem.OnHealed += HealthSystem_OnHealed;
        _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;


    }
    public void Damage(float damage)
    {
        _healthSystem.Damage(damage);
    }

    public void Spawn(GameObject[] pfEnemy, float delayNextSpawner, int maxEnemy, GameObject vfxVortex)
    {
        StartCoroutine(EnemySpawn(pfEnemy, delayNextSpawner, maxEnemy, vfxVortex));

    }

    private IEnumerator EnemySpawn(GameObject[] pfEnemy, float delayNextSpawner, int maxEnemy, GameObject vfxVortex)
    {
        while (_currentEnemys.Count < maxEnemy)
        {
            _currentTimeSpawner += Time.deltaTime;

            if (_currentTimeSpawner > delayNextSpawner)
            {
                int enemyIndex = UnityEngine.Random.Range(0, pfEnemy.Length);
                int spawnPointIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
                GameObject enemy = Instantiate(pfEnemy[enemyIndex], _spawnPoints[spawnPointIndex].position, Quaternion.identity);
                GameObject Vortex = Instantiate(vfxVortex, _spawnPoints[spawnPointIndex].position, vfxVortex.transform.rotation);
                _currentEnemys.Add(enemy);
                _currentTimeSpawner = 0;
            }
            yield return null;

        }
        StartCoroutine(CheckEnemy());

    }

    private IEnumerator CheckEnemy()
    {
        bool isEnemyHere = true;
        while (isEnemyHere)
        {
            GameObject enemy = GameObject.FindWithTag("Enemy");
            if (enemy == null) isEnemyHere = false;
            yield return null;
        }
    }


    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        //
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        Die();

    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        //Debug.Log(name + "CurrentHealth " + _healthSystem.GetHealth());
    }
    private void HealthSystem_OnHealed(object sender, EventArgs e)
    {
      //  Debug.Log(name + "Healed");
    }

    private void Die()
    {
        OnCrystalDestroyed?.Invoke();

        for (int i = 0; i < _enemyAmount; i++)
        {
            int enemyIndex = UnityEngine.Random.Range(0, _pfEnemy.Length);
            GameObject enemy = Instantiate(_pfEnemy[enemyIndex], _spawnPoint.position, Quaternion.identity);
            GameObject Vortex = Instantiate(_vfxVortex, _spawnPoint.position, _vfxVortex.transform.rotation);

        }

        Destroy(gameObject);
    }

}
