using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArenaManager : MonoBehaviour
{
    [Header("Первая арена")]
    [SerializeField] private GameObject _spawnerOne;
    [SerializeField] private GameObject _arenaGateOne;
    [SerializeField] private GameObject _backGate;
    [SerializeField] private GameObject _vfxVortex;
    [SerializeField] private GameObject[] _enemyPrefabsOne;
    [SerializeField] private float _delayNextSpawnerOne = 2f;
    [SerializeField] private int _maxEnemyOne = 5;

    [Header("Вторая арена")]
    [SerializeField] private GameObject _spawnerTwo;
    [SerializeField] private GameObject _arenaGateTwo;
    [SerializeField] private GameObject[] _enemyPrefabsTwo;
    [SerializeField] private float _delayNextSpawnerTwo = 2f;
    [SerializeField] private int _maxEnemyTwo = 5;

    //  [SerializeField] private GameObject _gateLift;

    [Header("Третья арена")]
    [SerializeField] private GameObject _spawnerThree;
    [SerializeField] private GameObject _arenaGateThree;
    [SerializeField] private GameObject[] _enemyPrefabsThree;
    [SerializeField] private float _delayNextSpawnerThree = 2f;
    [SerializeField] private int _maxEnemyThree = 5;

    [Header("Четвертая арена")]
    [SerializeField] private GameObject _spawnerFour;
    [SerializeField] private GameObject _arenaGateFour;
    [SerializeField] private GameObject[] _enemyPrefabsFour;
    [SerializeField] private float _delayNextSpawnerFour = 2f;
    [SerializeField] private int _maxEnemyFour = 5;

    [Header("Пятая арена")]
    [SerializeField] private GameObject _spawnerFive;
    [SerializeField] private GameObject _arenaGateFive;
    [SerializeField] private GameObject[] _enemyPrefabsFive;
    [SerializeField] private float _delayNextSpawnerFive = 2f;
    [SerializeField] private int _maxEnemyFive = 5;

    [Header("Кристалы")]
    [SerializeField] private GameObject _crystalOne;
    [SerializeField] private GameObject _crystalTwo;
    [SerializeField] private GameObject _crystalThree;
    [SerializeField] private GameObject _crystalFour;
    private int _crystalCount;
    [SerializeField] private TMP_Text _crystalCountText;


    [Header("Главные ворота")]
    [SerializeField] private GameObject _mainGate;

    private void OnEnable()
    {
        ArenaType.OnFirstArena += FirstArenaOpen;
        ArenaType.OnSecondArena += SecondArenaOpen;
        ArenaType.OnThirdArena += ThirdArenaOpen;
        ArenaType.OnFourthArena += FourthArenaOpen;
        ArenaType.OnFifthArena += FifthArenaOpen;

        _crystalCount = 4;
        _crystalCountText.SetText(_crystalCount.ToString());

        _arenaGateOne.SetActive(false);
        _backGate.SetActive(false);
        _arenaGateTwo.SetActive(false);
        _arenaGateThree.SetActive(false);
        _arenaGateFour.SetActive(false);
        _arenaGateFive.SetActive(false);
        _mainGate.SetActive(true);
    }

    private void OnDisable()
    {
        ArenaType.OnFirstArena -= FirstArenaOpen;
        ArenaType.OnSecondArena -= SecondArenaOpen;
        ArenaType.OnThirdArena -= ThirdArenaOpen;
        ArenaType.OnFourthArena -= FourthArenaOpen;
        ArenaType.OnFifthArena -= FifthArenaOpen;
    }

    private void CrystalCount()
    {
        if (_crystalCount <= 0)
        {
            Debug.Log("NowMoreCrystals");
            _mainGate.SetActive(false);
            _backGate.SetActive(false);

        }
        else
        {
            _crystalCount -= 1;
        }
        _crystalCountText.SetText(_crystalCount.ToString());
    }

    private void FirstArenaOpen()
    {
        _arenaGateOne.SetActive(true);
        _backGate.SetActive(true);
        _arenaGateTwo.SetActive(true);
        _arenaGateThree.SetActive(true);
        _arenaGateFour.SetActive(true);
        _arenaGateFive.SetActive(true);

        CristalController.OnCrystalDestroyed += FirstArenaClose;

        // Spawner.OnSpawnEnds += FirstArenaClose;

        _crystalOne.GetComponent<CristalController>().Spawn(_enemyPrefabsOne, _delayNextSpawnerOne, _maxEnemyOne, _vfxVortex);
    }



    private void SecondArenaOpen()
    {
        //Spawner.OnSpawnEnds += SecondArenaClose;
        CristalController.OnCrystalDestroyed += SecondArenaClose;

        _crystalTwo.GetComponent<CristalController>().Spawn(_enemyPrefabsTwo, _delayNextSpawnerTwo, _maxEnemyTwo, _vfxVortex);
    }

    private void ThirdArenaOpen()
    {
        // Spawner.OnSpawnEnds += ThirdArenaClose;
        CristalController.OnCrystalDestroyed += ThirdArenaClose;

        _crystalThree.GetComponent<CristalController>().Spawn(_enemyPrefabsThree, _delayNextSpawnerThree, _maxEnemyThree, _vfxVortex);

    }

    private void FourthArenaOpen()
    {
        //  Spawner.OnSpawnEnds += FourthArenaClose;
        CristalController.OnCrystalDestroyed += FourthArenaClose;

        _crystalFour.GetComponent<CristalController>().Spawn(_enemyPrefabsFour, _delayNextSpawnerFour, _maxEnemyFour, _vfxVortex);

    }

    private void FifthArenaOpen()
    {
        //  Spawner.OnSpawnEnds += FifthArenaClose;
        CristalController.OnCrystalDestroyed += FifthArenaClose;

        _spawnerFive.GetComponent<CristalController>().Spawn(_enemyPrefabsFive, _delayNextSpawnerFive, _maxEnemyFive, _vfxVortex);

    }

    private void FirstArenaClose()
    {
        _arenaGateOne.SetActive(false);
        // Spawner.OnSpawnEnds -= FirstArenaClose;
        CristalController.OnCrystalDestroyed -= FirstArenaClose;
        CrystalCount();
    }
    private void SecondArenaClose()
    {

        _arenaGateTwo.SetActive(false);
        // Spawner.OnSpawnEnds -= SecondArenaClose;
        CristalController.OnCrystalDestroyed -= SecondArenaClose;
        CrystalCount();
    }
    private void ThirdArenaClose()
    {
        _arenaGateThree.SetActive(false);
        // Spawner.OnSpawnEnds -= ThirdArenaClose;
        CristalController.OnCrystalDestroyed -= ThirdArenaClose;
        CrystalCount();
    }
    private void FourthArenaClose()
    {
        _arenaGateFour.SetActive(false);
        //  Spawner.OnSpawnEnds -= FourthArenaClose;
        CristalController.OnCrystalDestroyed -= FourthArenaClose;
        CrystalCount();

    }
    private void FifthArenaClose()
    {
        _arenaGateFive.SetActive(false);
        // Spawner.OnSpawnEnds -= FifthArenaClose;
        CristalController.OnCrystalDestroyed -= FifthArenaClose;

        CrystalCount();

        //Debug.Log("NowMoreCrystals");
        //_mainGate.SetActive(false);
        //_backGate.SetActive(false);
    }
}
