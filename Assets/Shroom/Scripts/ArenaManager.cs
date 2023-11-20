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
    [SerializeField] private Animator _mainGateAnimator;
    [SerializeField] private Transform _santaPointSpawn;
    [SerializeField] private Transform _pfSanta;
    [SerializeField] private GameObject _hpPanel;

    private void OnEnable()
    {
        ArenaType.OnFirstArena += FirstArenaOpen;
        ArenaType.OnSecondArena += SecondArenaOpen;
        ArenaType.OnThirdArena += ThirdArenaOpen;
        ArenaType.OnFourthArena += FourthArenaOpen;
        ArenaType.OnFifthArena += FifthArenaOpen;
        ArenaType.OnSantaArena += SantaArenaOpen;

        _mainGateAnimator.SetBool("isGateOpen", false);

        _crystalCount = 4;
        _crystalCountText.SetText(_crystalCount.ToString());

        _arenaGateOne.SetActive(false);
        _backGate.SetActive(false);
        _arenaGateTwo.SetActive(false);
        _arenaGateThree.SetActive(false);
        _arenaGateFour.SetActive(false);
        _arenaGateFive.SetActive(false);
       // _mainGate.SetActive(true);
    }

    private void OnDisable()
    {
        ArenaType.OnFirstArena -= FirstArenaOpen;
        ArenaType.OnSecondArena -= SecondArenaOpen;
        ArenaType.OnThirdArena -= ThirdArenaOpen;
        ArenaType.OnFourthArena -= FourthArenaOpen;
        ArenaType.OnFifthArena -= FifthArenaOpen;
        ArenaType.OnSantaArena -= SantaArenaOpen;

    }

    private void CrystalCount()
    {
        if (_crystalCount < 1)
        {
            //_mainGate.SetActive(false);
            _mainGateAnimator.SetBool("isGateOpen", false);
            SoundManager.PlaySound(SoundManager.Sound.GatesSound);

            //   _backGate.SetActive(false);
            //  Instantiate(_pfSanta, _santaPointSpawn.position, Quaternion.identity);
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
          Spawner.OnSpawnEnds += FifthArenaClose;
        //CristalController.OnCrystalDestroyed += FifthArenaClose;

       _spawnerFive.GetComponent<Spawner>().Spawn(_enemyPrefabsFive, _delayNextSpawnerFive, _maxEnemyFive, _vfxVortex);

    }

    private void FirstArenaClose()
    {
        // Spawner.OnSpawnEnds -= FirstArenaClose;
        CristalController.OnCrystalDestroyed -= FirstArenaClose;
        StartCoroutine(CheckEnemy(_arenaGateOne));
        CrystalCount();
    }
    private void SecondArenaClose()
    {

        // Spawner.OnSpawnEnds -= SecondArenaClose;
        CristalController.OnCrystalDestroyed -= SecondArenaClose;
        StartCoroutine(CheckEnemy(_arenaGateTwo));
        CrystalCount();
    }
    private void ThirdArenaClose()
    {

        // Spawner.OnSpawnEnds -= ThirdArenaClose;
        CristalController.OnCrystalDestroyed -= ThirdArenaClose;
        StartCoroutine(CheckEnemy(_arenaGateThree));
        CrystalCount();
    }
    private void FourthArenaClose()
    {
        //  Spawner.OnSpawnEnds -= FourthArenaClose;
        CristalController.OnCrystalDestroyed -= FourthArenaClose;
        StartCoroutine(CheckEnemy(_arenaGateFour));
        CrystalCount();

    }
    private void FifthArenaClose()
    {
        Spawner.OnSpawnEnds -= FifthArenaClose;
        StartCoroutine(CheckEnemy(_arenaGateFive));
        //CristalController.OnCrystalDestroyed -= FifthArenaClose;

        CrystalCount();

        //Debug.Log("NowMoreCrystals");
        //_mainGate.SetActive(false);
        //_backGate.SetActive(false);
        _mainGateAnimator.SetBool("isGateOpen", true);
        SoundManager.PlaySound(SoundManager.Sound.GatesSound);

    }

    private IEnumerator CheckEnemy(GameObject gates)
    {
        yield return new WaitForSeconds(1f);
        bool isEnemyHere = true;
        while (isEnemyHere)
        {
            GameObject enemy = GameObject.FindWithTag("Enemy");
            if (enemy == null) isEnemyHere = false;
            yield return null;
        }
        OpenGates(gates);
    }

    private void OpenGates(GameObject gates)
    {
        gates.SetActive(false);
    }

    private void SantaArenaOpen()
    {
        _hpPanel.SetActive(true);
        Instantiate(_pfSanta, _santaPointSpawn.position, Quaternion.identity);
        // _mainGate.SetActive(true);
        _mainGateAnimator.SetBool("isGateOpen", false);
        SoundManager.PlaySound(SoundManager.Sound.GatesSound);

    }
}
