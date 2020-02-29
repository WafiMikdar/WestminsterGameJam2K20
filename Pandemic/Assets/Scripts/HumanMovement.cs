using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanHealth))]
public class HumanMovement : MonoBehaviour
{
    [SerializeField] private float healthySpeed, infectedSpeed;

    private HumanHealth health;

    private Transform monsterTransform;

    private void Awake()
    {
        health = GetComponent<HumanHealth>();
        monsterTransform = GameObject.FindWithTag("Monster").transform;
    }
}