using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private int doctorWinBuildIndex, monsterWinBuildIndex;

    private static WinScreen instance;

    public static WinScreen Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<WinScreen>();
            }

            return instance;
        }
    }

    public void DisplayMonsterWin()
    {
        SceneManager.LoadScene(monsterWinBuildIndex);
    }

    public void DisplayDoctorWin()
    {
        SceneManager.LoadScene(doctorWinBuildIndex);
    }
}