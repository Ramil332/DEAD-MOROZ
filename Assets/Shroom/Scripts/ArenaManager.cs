using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [Header("Первая арена")]
    [SerializeField] private GameObject _spawnerOne;
    [SerializeField] private GameObject _arenaGateOne;
    [SerializeField] private GameObject _vfxVortex;
    [SerializeField] private GameObject[] _enemyPrefabsOne;
    [SerializeField] private float _delayNextSpawnerOne = 2f;
    [SerializeField] private int _maxEnemyOne = 5;

    [Header("Вторая арена")]
    [SerializeField] private GameObject _spawnerTwo;
    [SerializeField] private GameObject _arenaGateTwo;

    [Header("Третья арена")]
    [SerializeField] private GameObject _spawnerThree;
    [SerializeField] private GameObject _arenaGateThree;

    [Header("Четвертая арена")]
    [SerializeField] private GameObject _spawnerFour;
    [SerializeField] private GameObject _arenaGateFour;

    [Header("Пятая арена")]
    [SerializeField] private GameObject _spawnerFive;
    [SerializeField] private GameObject _arenaGateFive;


    private void OnEnable()
    {
        ArenaType.OnFirstArena += FirstArenaOpen;
        ArenaType.OnSecondArena += SecondArena;
        ArenaType.OnThirdArena += ThirdArena;
        ArenaType.OnFourthArena += FourthArena;
        ArenaType.OnFifthArena += FifthArena;

        _arenaGateOne.SetActive(false);
        _arenaGateTwo.SetActive(false);
        _arenaGateThree.SetActive(false);
        _arenaGateFour.SetActive(false);
        _arenaGateFive.SetActive(false);

    }

    private void OnDisable()
    {
        ArenaType.OnFirstArena -= FirstArenaOpen;
        ArenaType.OnSecondArena -= SecondArena;
        ArenaType.OnThirdArena -= ThirdArena;
        ArenaType.OnFourthArena -= FourthArena;
        ArenaType.OnFifthArena -= FifthArena;

    }

    private void FirstArenaOpen()
    {
        _arenaGateOne.SetActive(true);
        _arenaGateTwo.SetActive(true);
        _arenaGateThree.SetActive(true);
        Spawner.OnSpawnEnds += FirstArenaClose;

        _spawnerOne.GetComponent<Spawner>().Spawn(_enemyPrefabsOne, _delayNextSpawnerOne, _maxEnemyOne, _vfxVortex);
    }

    private void FirstArenaClose()
    {
        _arenaGateTwo.SetActive(false);
        Spawner.OnSpawnEnds -= FirstArenaClose;
    }


    private void SecondArena()
    {

    }
    private void ThirdArena()
    {

    }

    private void FourthArena()
    {

    }

    private void FifthArena()
    {

    }
}
