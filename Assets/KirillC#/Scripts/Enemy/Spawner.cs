using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;

    //[SerializeField]private float _deleyNextSpawner = 2f;
    //[SerializeField]private float _maxEnemy = 5f;

    private List<GameObject> _currentEnemys = new List<GameObject>();
    private float _currentTimeSpawner = 0f;

    public List<GameObject> CurrentEnemys => _currentEnemys;
    //public float MaxEnemy => _maxEnemy;

    public static Action OnSpawnEnds;

    private void Update()
    {
        //  SpawnNextEnemy();
    }

    //public void SpawnNextEnemy()
    //{
    //    if (_currentEnemys.Count < _maxEnemy && _currentTimeSpawner > _deleyNextSpawner)
    //    {
    //    Debug.Log("Spawner Activate");
    //        int enemyIndex = Random.Range(0, _enemyPrefabs.Length);
    //        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
    //        GameObject enemy = Instantiate(_enemyPrefabs[enemyIndex], _spawnPoints[spawnPointIndex].position, Quaternion.identity);
    //        _currentEnemys.Add(enemy);

    //        _currentTimeSpawner = 0;
    //    }
    //}

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
                Debug.Log("Spawner Activate");
                int enemyIndex = UnityEngine.Random.Range(0, pfEnemy.Length);
                int spawnPointIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
                GameObject enemy = Instantiate(pfEnemy[enemyIndex], _spawnPoints[spawnPointIndex].position, Quaternion.identity);
                GameObject Vortex = Instantiate(vfxVortex, _spawnPoints[spawnPointIndex].position, vfxVortex.transform.rotation);
               // Destroy(Vortex, 2f);
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
        OnSpawnEnds?.Invoke();

    }
}