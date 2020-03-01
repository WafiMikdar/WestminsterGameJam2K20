using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class MonsterProgression : MonoBehaviour
{
    [SerializeField] private FadingNotification notifier;

    [SerializeField] private string lethalInfectingUnlockNotification = "Lethal infecting unlocked, press Q to quickly kill people nearby";
    [SerializeField] private string ultravisionUnlockNotification = "Ultravision unlocked, press E to see nearby traps and sensors";

    public Animator anim;

    public bool level1 = true; // Why, oh god why would you ever need to make these?!
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
                notifier.CreateNotification(lethalInfectingUnlockNotification);
                Debug.Log("Level 2");
                anim.SetBool("level2", true);
                anim.SetBool("level1", false);
                break;

            case 2:
                GetComponent<MonsterUltravision>().Unlock();
                notifier.CreateNotification(ultravisionUnlockNotification);
                Debug.Log("Level 3");
                anim.SetBool("level3", true);
                anim.SetBool("level2", false);
                break;

            case 3:
                WinScreen.Instance.DisplayMonsterWin();
                break;
        }
    }
}