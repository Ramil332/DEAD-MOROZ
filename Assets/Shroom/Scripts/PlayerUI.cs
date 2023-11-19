using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _healthsPanel;
    [SerializeField] private GameObject _crystalPanel;
    [SerializeField] private GameObject _weaponPanel;
    [SerializeField] private GameObject _santaHPPanel;
    //[SerializeField] private GameObject _soundPanel;
    //[SerializeField] private GameObject _nextLvlPanel;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _deathRestartButton;
    //[SerializeField] private GameObject _nextLvlButton;

    private InputManager _inputManager;
    private bool _isPause, _isDied;

    private void Awake()
    {
        Time.timeScale = 1f;
        _isPause = false;

        _deathPanel.SetActive(false);
        _winPanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _healthsPanel.SetActive(true);
        _crystalPanel.SetActive(true);
        _weaponPanel.SetActive(true);
        _santaHPPanel.SetActive(false);
        //_nextLvlPanel.SetActive(false);
        //_soundPanel.SetActive(false);
        _pausePanel.SetActive(false);

    }

    private void Start()
    {
        _inputManager = InputManager.InputInstance;
        PlayerHealth.OnDied += PlayerDied;
        _isDied = false;
    }
    public void BackInGame()
    {
        _pausePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _healthsPanel.SetActive(true);
        _crystalPanel.SetActive(true);
        _weaponPanel.SetActive(true);
        if(_santaHPPanel.activeSelf) _santaHPPanel.SetActive(true);
        else _santaHPPanel.SetActive(false);

        //_soundPanel.SetActive(false);
        Cursor.visible = false;

        Time.timeScale = 1f;
        _isPause = false;

    }

    private void Update()
    {
        if (_inputManager.Pause())
        {
            if(!_isDied) PauseGame();

        }

    }

    private void PauseGame()
    {
       // _isPause = !_isPause;

        //if (_isPause)
        //{
        //    BackInGame();
        //}
        //else
        //{
        //}
        _pausePanel.SetActive(true);
        _healthsPanel.SetActive(false);
        _crystalPanel.SetActive(false);
        _weaponPanel.SetActive(false);
        _santaHPPanel.SetActive(false);

        Cursor.visible = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_restartButton);

        Time.timeScale = 0f;

    }

    private void PlayerDied()
    {
        _isDied = true;
        PlayerHealth.OnDied -= PlayerDied;

        _deathPanel.SetActive(true);
        _healthsPanel.SetActive(false);
        _crystalPanel.SetActive(false);
        _weaponPanel.SetActive(false);
        _santaHPPanel.SetActive(false);

        Cursor.visible = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_deathRestartButton);
    }

    public void WinGame()
    {
        Invoke(nameof(WinPanel), 1f);
    }

    private void WinPanel()
    {
        _winPanel.SetActive(true);
    }

}
