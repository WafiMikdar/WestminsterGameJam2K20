using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedLoadMainMenu : MonoBehaviour
{
    [SerializeField] private float delay = 5;

    [SerializeField] private int mainMenuBuildIndex;

    private void Awake()
    {
        Invoke("LoadMainMenu", delay);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuBuildIndex);
    }
}