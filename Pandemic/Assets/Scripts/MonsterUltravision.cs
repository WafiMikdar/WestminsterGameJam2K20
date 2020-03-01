using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUltravision : UnlockableCooldownAbility
{
    [SerializeField] private float duration;
    [SerializeField] private MonsterSfx monsterSfx;

    [SerializeField] private Camera monsterCamera;

    [SerializeField] private LayerMask ultravision;
    private LayerMask normalVision;

    private void Start()
    {
        normalVision = monsterCamera.cullingMask;
    }

    public void TryActivate()
    {
        if (IsReady)
        {
            Activate();
            monsterSfx.PlaySFX(monsterSfx.MonsterUltraVision);
            ResetCooldown();
        }
    }

    private void Activate()
    {
        monsterCamera.cullingMask = ultravision;
        Invoke("Deactivate", duration);
    }

    private void Deactivate()
    {
        monsterCamera.cullingMask = normalVision;
    }
}