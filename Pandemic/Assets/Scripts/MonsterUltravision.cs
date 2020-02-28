using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUltravision : MonoBehaviour
{
    [SerializeField] private float cooldown, duration;
    private float readyTime;

    [SerializeField] private Camera monsterCamera;

    [SerializeField] private LayerMask ultravision;
    private LayerMask normalVision;

    private void Start()
    {
        normalVision = monsterCamera.cullingMask;
    }

    public void TryActivate()
    {
        if (Time.time >= readyTime)
        {
            Activate();
            readyTime = Time.time + cooldown;
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