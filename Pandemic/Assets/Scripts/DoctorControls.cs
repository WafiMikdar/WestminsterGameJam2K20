using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoctorControls : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 doctorVelocity;
    [SerializeField] private DoctorAdrenalinBoost dab;

    public float Speed { get => speed; set => speed = value; }

    private void Move()
    {
        Vector2 movementVector2 = new Vector2(doctorVelocity.x, doctorVelocity.y) * speed * Time.deltaTime;
        transform.Translate(movementVector2);
        if (doctorVelocity.y > movementVector2.y) { Debug.Log("up"); }
        if (doctorVelocity.y < movementVector2.y) { Debug.Log("down"); }
        if (doctorVelocity.x < movementVector2.x) { Debug.Log("left"); }
        if (doctorVelocity.x > movementVector2.x) { Debug.Log("right"); }
    }

    private void OnMove(InputValue value)
    {
        doctorVelocity = value.Get<Vector2>();
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
        Debug.Log("Ability One");
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
        dab.AdrenalinBoost();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
