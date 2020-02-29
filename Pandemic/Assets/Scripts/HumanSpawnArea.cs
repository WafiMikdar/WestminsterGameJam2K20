using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class HumanSpawnArea : MonoBehaviour
{
    [SerializeField, Tooltip("index 0 and 1 should be male characters")] private GameObject[] prefabs;

    [SerializeField] private float minSpawnCooldown, maxSpawnCooldown;

    [SerializeField] private uint maxSpawned;

    private BoxCollider2D coll;

    private List<ICallOnDestroy> spawned = new List<ICallOnDestroy>();

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        yield return new WaitUntil(() => spawned.Count < maxSpawned);
        yield return new WaitForSeconds(Random.Range(minSpawnCooldown, maxSpawnCooldown));
        Spawn();
        StartCoroutine(Spawning());
    }

    private void Spawn()
    {
        int chosenPrefab = Random.Range(0, prefabs.Length);
        HumanMovement newMovement = Instantiate(prefabs[chosenPrefab], GetSpawnPosition(), Quaternion.identity, transform).GetComponent<HumanMovement>();
        newMovement.IsMale = chosenPrefab == 0 || chosenPrefab == 1;
        ICallOnDestroy newInstance = newMovement.GetComponent<ICallOnDestroy>();
        spawned.Add(newInstance);
        newInstance?.SetupCallOnDestroy(() => RemoveSpawned(newInstance));
    }

    private void RemoveSpawned(ICallOnDestroy toRemove) => spawned.Remove(toRemove);

    private Vector2 GetSpawnPosition()
    {
        return new Vector2(Random.Range(coll.bounds.min.x, coll.bounds.max.x),
                           Random.Range(coll.bounds.min.y, coll.bounds.max.y));
    }
}