using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanHealth), typeof(Rigidbody2D))]
public class HumanMovement : MonoBehaviour
{
    [SerializeField] private float healthySpeed, infectedSpeed, detectionRange, slowDownFactor, stoppingSpeed;
    private float sqrDetectionRange, sqrStoppingSpeed;

    private HumanHealth health;

    private Rigidbody2D rb;

    private Transform monsterTransform;

    public Animator anim;
    private SpriteRenderer spR;
    public float vel;

    private bool isFleeing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sqrDetectionRange = detectionRange * detectionRange;
        sqrStoppingSpeed = stoppingSpeed * stoppingSpeed;
        health = GetComponent<HumanHealth>();
        monsterTransform = GameObject.FindWithTag("Monster").transform;
    }
    private void Start()
    {
        spR = GetComponent<SpriteRenderer>();
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
        vel = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2)));
        anim.SetFloat("Vel", vel);
    }

    private void Move(Vector2 dir)
    {
        rb.velocity = dir * (health.IsHealthy ? healthySpeed : infectedSpeed);
        
        if (rb.velocity.x < 0)
        {
            spR.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spR.flipX = false;
        }
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