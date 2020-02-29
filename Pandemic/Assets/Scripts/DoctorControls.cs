using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoctorControls : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 doctorVelocity;
    [SerializeField] private DoctorAdrenalinBoost dab;

    [SerializeField] private DoctorCuring curing;
    [SerializeField] private DoctorTrapPlacer trapPlacer;
    [SerializeField] private MotionSensorPlacer sensorPlacer;
    [SerializeField] private SupplyDropAbilitySlot supplyDropAbility;

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
        Vector2 movementVector2 = new Vector2(doctorVelocity.x, doctorVelocity.y) * speed * Time.deltaTime;
        transform.Translate(movementVector2);
        if (doctorVelocity.x < 0)
        {
            spR.flipX = true;
        }
        else if (doctorVelocity.x > 0)
        {
            spR.flipX = false;
        }
        vel = Mathf.Sqrt(Mathf.Pow(movementVector2.x, 2) + Mathf.Pow(movementVector2.y, 2));
        //Debug.Log(vel);
        if (doctorVelocity.y > movementVector2.y)
        {
            //Debug.Log("up");
            anim.Play("Run");
        }
        anim.SetFloat("Vel", vel);
        if (doctorVelocity.y < movementVector2.y)
        {
            //Debug.Log("down");
            anim.Play("Run");
        }

        if (doctorVelocity.x < movementVector2.x)
        {
            //Debug.Log("left");
            anim.Play("Run");
        }

        if (doctorVelocity.x > movementVector2.x)
        {
            //Debug.Log("right");
            anim.Play("Run");
        }
    }

    private void OnMove(InputValue value)
    {
        doctorVelocity = value.Get<Vector2>();
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
        sensorPlacer.TryActivate();
    }

    private void OnAbilityThree()
    {
        supplyDropAbility.TryActivate();
    }

    private void OnAbilityFour()
    {
        Debug.Log("DoctorAbility Four");
    }

    private void OnAbilityFive()
    {
        // speed = dab.adrenalinBoost(ref speed);
    }

    private void FixedUpdate()
    {
        Move();
    }
}