using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaBossController : Enemy
{
    private Animator _santaAnimator;

    [SerializeField] private float _delaySpawnMobs = 10f;
    [SerializeField] private GameObject[] _mobPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    private float _currentTimeDeleySpawnMobe = 0f;

    private void Start()
    {
        _santaAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        _currentTimeDeleySpawnMobe += Time.deltaTime;

        if (GetComponent<EnemyMovement>().IsAttacking)
        {
            _currentTimeDeleySpawnMobe -= 2f;

            return;
        }
        if(_currentTimeDeleySpawnMobe >= _delaySpawnMobs)
        {
            _santaAnimator.SetTrigger("SpawnMobs");
            _currentTimeDeleySpawnMobe = 0;
        }

    }

    public void SantaSpawnMobs()
    {
        if (!GetComponent<SantaHealth>().Died)
        {
            SoundManager.PlaySound(SoundManager.Sound.SantaHoHoHo);
            int indexMob1 = Random.Range(0, _mobPrefabs.Length);
            int indexMob2 = Random.Range(0, _mobPrefabs.Length);
            int indexMob3 = Random.Range(0, _mobPrefabs.Length);

            int indexPoint1 = Random.Range(0, _spawnPoints.Length);
            int indexPoint2 = Random.Range(0, _spawnPoints.Length);
            int indexPoint3 = Random.Range(0, _spawnPoints.Length);

            Instantiate(_mobPrefabs[indexMob1], _spawnPoints[indexPoint1].position, Quaternion.identity);
            Instantiate(_mobPrefabs[indexMob2], _spawnPoints[indexPoint2].position, Quaternion.identity);
            Instantiate(_mobPrefabs[indexMob3], _spawnPoints[indexPoint3].position, Quaternion.identity);

        }
    }
}
