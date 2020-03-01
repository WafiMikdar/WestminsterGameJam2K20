using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public static bool PauseEnabled;

    [SerializeField] private int mainMenuBuildIndex;

    private int pressed = 0;

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        PauseEnabled = false;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        PauseEnabled = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(mainMenuBuildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void OnPauseMenu()
    {
        if (PauseEnabled)
            Resume();
        else
            Pause();
    }
}