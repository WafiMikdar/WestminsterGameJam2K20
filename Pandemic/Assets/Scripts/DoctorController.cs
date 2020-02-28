using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoctorController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 playerVelocity;

    [SerializeField] private DoctorCuring curing;
    [SerializeField] private DoctorTrapPlacer trapPlacer;
    [SerializeField] private MotionSensorPlacer sensorPlacer;
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
        curing.TryCure();
    }

    private void OnAbilityOne()
    {
        trapPlacer.TryPlaceTrap();
    }

    private void OnAbilityTwo()
    {
        sensorPlacer.TryPlaceSensor();
    }

    private void FixedUpdate()
    {
        Move();
    }
}