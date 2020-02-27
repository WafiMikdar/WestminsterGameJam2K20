using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 playerMovmentVector2;
    private float velocity = 5f;
 


    private void move()
    {
        Vector2 movementVector2 = new Vector2(playerMovmentVector2.x, playerMovmentVector2.y) * velocity * Time.deltaTime;
        transform.Translate(movementVector2);
    }

    private void OnMove(InputValue value) { playerMovmentVector2 = value.Get<Vector2>(); }

    private void OnAttack() { Debug.Log("Attacked"); }

    private void OnAbilityOne() { Debug.Log("Ability One"); }

    private void OnAbilityTwo() { Debug.Log("Ability Two"); }

    private void FixedUpdate()
    { 
        move();
    }

}
//