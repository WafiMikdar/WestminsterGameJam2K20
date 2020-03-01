using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class MonsterProgression : MonoBehaviour
{

    [SerializeField] private MonsterSfx monsterSfx;
    private void Awake()
    {
        GetComponent<Experience>().onLevelUp += LevelUp;
        monsterSfx.PlaySFX(monsterSfx.MonsterEvolution);
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