using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    private List<GameObject> _currentEnemys = new List<GameObject>();
    private float _currentTimeSpawner = 0f;
    public List<GameObject> CurrentEnemys => _currentEnemys;

    public static Action OnSpawnEnds;

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
            Debug.Log("Ybei vsex");
           GameObject enemy = GameObject.FindWithTag("Enemy");
            if (enemy == null) isEnemyHere = false;
            yield return null;
        }
        OnSpawnEnds?.Invoke();

    }
}