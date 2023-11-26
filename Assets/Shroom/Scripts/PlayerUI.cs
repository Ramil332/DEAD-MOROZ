using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _healthsPanel;
    [SerializeField] private GameObject _crystalAndSantaPanel;
    [SerializeField] private GameObject _weaponPanel;
    [SerializeField] private GameObject _santaPanel;
    [SerializeField] private GameObject _helperPanel;
    //[SerializeField] private GameObject _soundPanel;
    //[SerializeField] private GameObject _nextLvlPanel;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _deathRestartButton;
    //[SerializeField] private GameObject _nextLvlButton;

    private InputManager _inputManager;
    private bool _isPause, _isDied;

    private void Awake()
    {
        Time.timeScale = 0f;
        _isPause = false;

        _healthsPanel.SetActive(true);
        _deathPanel.SetActive(false);
        _winPanel.SetActive(false);
        _optionsPanel.SetActive(false);
        //
        _healthsPanel.SetActive(false);
        _crystalAndSantaPanel.SetActive(false);
        _weaponPanel.SetActive(false); 
        _santaPanel.SetActive(false); 
        //
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
        Time.timeScale = 1f;

        _inputManager.InputEnable();

        _pausePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _healthsPanel.SetActive(true);

        _crystalAndSantaPanel.SetActive(true);
       

        _weaponPanel.SetActive(true);

         _santaPanel.SetActive(true);

        //_soundPanel.SetActive(false);
        //Cursor.visible = false;

        _isPause = false;

    }

    private void Update()
    {
        if (_inputManager.Pause())
        {
            if (!_isDied)
            {
                PauseGame();
                _inputManager.InputDisable();
            }

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
        if (_isDied)
        {
            _deathPanel.SetActive(true);

        }
        else
        _pausePanel.SetActive(true);

        _healthsPanel.SetActive(false);
        _crystalAndSantaPanel.SetActive(false);
        _weaponPanel.SetActive(false);
        _santaPanel.SetActive(false);
       // Cursor.visible = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_restartButton);

        Time.timeScale = 0f;

    }

    private void PlayerDied()
    {
        _isDied = true;
        PlayerHealth.OnDied -= PlayerDied;

        PauseGame();
        //_deathPanel.SetActive(true);
        //_healthsPanel.SetActive(false);
        //_crystalAndSantaPanel.SetActive(false);
        //_weaponPanel.SetActive(false);
        //_santaPanel.SetActive(false);
        //Cursor.visible = true;


        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(_deathRestartButton);
    }

    public void HelperPanel()
    {
        _helperPanel.SetActive(false);
        _healthsPanel.SetActive(true);
        _crystalAndSantaPanel.SetActive(true);
        _weaponPanel.SetActive(true);
        _santaPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void WinGame()
    {
        Invoke(nameof(WinPanel), 3f);
    }

    private void WinPanel()
    {
        _winPanel.SetActive(true);
        _healthsPanel.SetActive(false);
        _crystalAndSantaPanel.SetActive(false);
        _weaponPanel.SetActive(false);
        _santaPanel.SetActive(false);
        //Cursor.visible = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_restartButton);

        Time.timeScale = 0f;
        _inputManager.InputDisable();

    }

}
