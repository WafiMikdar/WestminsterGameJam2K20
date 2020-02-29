using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyDrop : MonoBehaviour
{
    private SupplyDropAbility doctorAbility, monsterAbility;

    public SupplyDropAbility DoctorAbility
    {
        get => doctorAbility;
        set => doctorAbility = value;
    }

    public SupplyDropAbility MonsterAbility
    {
        get => monsterAbility;
        set => monsterAbility = value;
    }

    private float spawnTime;
    public float SpawnTime => spawnTime;

    private void Awake()
    {
        spawnTime = Time.time;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}