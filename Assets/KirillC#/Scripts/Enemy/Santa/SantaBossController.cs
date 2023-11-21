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

        if(_currentTimeDeleySpawnMobe >= _delaySpawnMobs)
        {
            _santaAnimator.SetTrigger("SpawnMobs");
            _currentTimeDeleySpawnMobe = 0;
        }

    }

    public void SantaSpawnMobs()
    {
        SoundManager.PlaySound(SoundManager.Sound.SantaHoHoHo);
        int indexMob = Random.Range(0, _mobPrefabs.Length);
        int indexPoint = Random.Range(0, _spawnPoints.Length);
        Instantiate(_mobPrefabs[indexMob], _spawnPoints[indexPoint].position, Quaternion.identity);
    }
}
