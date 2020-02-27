using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 playerVelocity;

    public float Speed { get => speed; set => speed = value; }

    private void Move()
    {
        Vector2 movementVector2 = new Vector2(playerVelocity.x, playerVelocity.y) * speed * Time.deltaTime;
        transform.Translate(movementVector2);
    }

    private void OnMove(InputValue value)
    {
        playerVelocity = value.Get<Vector2>();
    }

    private void OnAttack()
    {
        Debug.Log("Attacked");
    }

    private void OnAbilityOne()
    {
        Debug.Log("Ability One");
    }

    private void OnAbilityTwo()
    {
        Debug.Log("Ability Two");
    }

    private void FixedUpdate()
    {
        Move();
    }
}

//