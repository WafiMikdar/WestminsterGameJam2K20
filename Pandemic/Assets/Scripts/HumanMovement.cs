﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanHealth), typeof(Rigidbody2D))]
public class HumanMovement : MonoBehaviour
{
    [SerializeField] private float healthySpeed, infectedSpeed, detectionRange, slowDownFactor, stoppingSpeed;
    [SerializeField] private HumanSFX humanSFX;
    private float sqrDetectionRange, sqrStoppingSpeed;

    public bool IsMale { get; set; } // TODO call PlayScreamSfx func from humanSFX instance (if true male scream, else female)

    private HumanHealth health;

    private Rigidbody2D rb;

    private Transform monsterTransform;

    private bool isFleeing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sqrDetectionRange = detectionRange * detectionRange;
        sqrStoppingSpeed = stoppingSpeed * stoppingSpeed;
        health = GetComponent<HumanHealth>();
        monsterTransform = GameObject.FindWithTag("Monster").transform;
    }

    private void FixedUpdate()
    {
        if (!monsterTransform)
        {
            return;
        }

        Vector2 diff = transform.position - monsterTransform.position;
        isFleeing = Vector2.SqrMagnitude(diff) <= sqrDetectionRange;

        if (isFleeing)
        {
            Move(diff.normalized);
        }
        else
        {
            SlowDown();
        }
    }

    private void Move(Vector2 dir)
    {
        rb.velocity = dir * (health.IsHealthy ? healthySpeed : infectedSpeed);
    }

    private void SlowDown()
    {
        if (rb.velocity.sqrMagnitude <= sqrStoppingSpeed)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity *= slowDownFactor;
        }
    }
}