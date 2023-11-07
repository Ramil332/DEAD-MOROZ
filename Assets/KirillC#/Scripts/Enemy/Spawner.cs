using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField]private float _deleyNextSpawner = 2f;
    [SerializeField]private float _maxEnemy = 5f;

    private List<GameObject> _currentEnemys = new List<GameObject>();
    private float _currentTimeSpawner;

    private void Update()
    {
        SpawnNextEnemy();
        _currentTimeSpawner += Time.deltaTime;
    }
    public void SpawnNextEnemy()
    {
        if (_currentEnemys.Count < _maxEnemy && _currentTimeSpawner > _deleyNextSpawner)
        {
        Debug.Log("Spawner Activate");
            int enemyIndex = Random.Range(0, _enemyPrefabs.Length);
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            GameObject enemy = Instantiate(_enemyPrefabs[enemyIndex], _spawnPoints[spawnPointIndex].position, Quaternion.identity);
            _currentEnemys.Add(enemy);

            _currentTimeSpawner = 0;
        }
    }
}