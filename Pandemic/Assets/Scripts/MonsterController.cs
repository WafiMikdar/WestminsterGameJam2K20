﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 monsterVelocity;

    [SerializeField] private MonsterInfecting infecting;

    public float Speed { get => speed; set => speed = value; }
    public Animator anim;
    private SpriteRenderer spR;
    public float vel;
    private void Start()
    {
        spR = GetComponent<SpriteRenderer>();
    }
    private void Move()
    {
        Vector2 movementVector2 = new Vector2(monsterVelocity.x, monsterVelocity.y) * speed * Time.deltaTime;
        transform.Translate(movementVector2);

        if (monsterVelocity.x < 0)
        {
            spR.flipX = true;
        }
        else if (monsterVelocity.x > 0)
        {
            spR.flipX = false;
        }
        vel = Mathf.Sqrt(Mathf.Pow(movementVector2.x, 2) + Mathf.Pow(movementVector2.y, 2));
        Debug.Log(vel);
        if (monsterVelocity.y > movementVector2.y)
        {
            Debug.Log("up");
            anim.Play("Run");
        }
        anim.SetFloat("Vel", vel);
        if (monsterVelocity.y < movementVector2.y)
        {
            Debug.Log("down");
            anim.Play("Run");
        }

        if (monsterVelocity.x < movementVector2.x)
        {
            Debug.Log("left");
            anim.Play("Run");
        }

        if (monsterVelocity.x > movementVector2.x)
        {
            Debug.Log("right");
            anim.Play("Run");
        }
    }

    private void OnMove(InputValue value)
    {
        monsterVelocity = value.Get<Vector2>();
    }

    private void OnAttack()
    {
        infecting.TryInfect();
    }

    private void OnAbilityOne()
    {
        Debug.Log("Ability One");
    }

    private void OnAbilityTwo()
    {
        Debug.Log("Ability Two");
    }

    private void OnAbilityThree()
    {
        Debug.Log("Ability Three");
    }

    private void OnAbilityFour()
    {
        Debug.Log("Ability Four");
    }

    private void OnAbilityFive()
    {
        Debug.Log("Ability Five");
    }

    private void FixedUpdate()
    {
        Move();
    }
}