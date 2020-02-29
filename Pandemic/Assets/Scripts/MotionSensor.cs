using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    [SerializeField] private float detectionRadius, indicatorVariance, indicatorDuration, notificationCooldown, duration;
    private float sqrDetectionRadius, notificationReadyTime;

    [SerializeField] private Color indicatorColor;

    [SerializeField] private LayerMask buildingLayer;

    private Transform monsterTransform, doctorTransform;

    private RadialBarIndicator indicator;

    private void Awake()
    {
        monsterTransform = GameObject.FindWithTag("Monster").transform;
        sqrDetectionRadius = detectionRadius * detectionRadius;
        Invoke("DestroyTrap", duration);
    }

    public void Setup(Transform doctorTransform, RadialBarIndicator indicator)
    {
        this.doctorTransform = doctorTransform;
        this.indicator = indicator;
    }

    private void Update()
    {
        if ((monsterTransform.position - doctorTransform.position).sqrMagnitude <= sqrDetectionRadius && Time.time >= notificationReadyTime)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, monsterTransform.position - transform.position, Vector2.Distance(monsterTransform.position, transform.position), buildingLayer);

            if (!hit.collider)
            {
                indicator.SetIndicator(Mathf.Atan2(doctorTransform.position.y - monsterTransform.position.y, doctorTransform.position.x - monsterTransform.position.x) * Mathf.Rad2Deg - 90,
                    indicatorVariance, indicatorDuration, indicatorColor);
                notificationReadyTime = Time.time + notificationCooldown;
            }
        }
    }

    private void DestroyTrap()
    {
        Destroy(gameObject);
    }
}