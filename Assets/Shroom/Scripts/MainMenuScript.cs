using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _startButton, _soundButton, _slider;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //public void LoreScene()
    //{
    //    SceneManager.LoadScene(1);
    //}
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackInGame()
    {
        PlayerUI playerUI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();
        if (playerUI != null) playerUI.BackInGame();
        else RestartScene();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void OptionsPanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_soundButton);
    }

    public void SoundPanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
       // EventSystem.current.SetSelectedGameObject(_slider);
    }

    public void MainMenuPanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_startButton);
    }
    public void URL(string link)
    {
        Application.OpenURL(link);
    }

}
