using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class MonsterProgression : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Experience>().onLevelUp += LevelUp;
    }

    private void LevelUp(uint newLevel)
    {
        switch (newLevel)
        {
            case 1:
                Debug.Log("Level 1");
                break;

            case 2:
                Debug.Log("Level 2");
                break;

            case 3:
                Debug.Log("Level 3");
                break;
        }
    }
}