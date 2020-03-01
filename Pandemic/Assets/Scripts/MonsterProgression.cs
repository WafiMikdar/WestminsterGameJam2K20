using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class MonsterProgression : MonoBehaviour
{
    public Animator anim;

    // Why, oh god why would you ever make these?!
    public bool level1 = true;

    public bool level2 = false;
    public bool level3 = false;

    [SerializeField] private MonsterSfx monsterSfx;

    private void Awake()
    {
        GetComponent<Experience>().onLevelUp += LevelUp;
    }

    private void LevelUp(uint newLevel)
    {
        monsterSfx.PlaySFX(monsterSfx.MonsterEvolution);
        switch (newLevel)
        {
            case 1:
                GetComponent<MonsterLethalInfecting>().Unlock();
                Debug.Log("Level 2");
                anim.SetBool("level2", true);
                anim.SetBool("level1", false);
                break;

            case 2:
                GetComponent<MonsterUltravision>().Unlock();
                Debug.Log("Level 3");
                anim.SetBool("level3", true);
                anim.SetBool("level2", false);
                break;
        }
    }
}