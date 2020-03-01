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
    [SerializeField] private DoctorAdrenalineBoost dab;
    [SerializeField] private DoctorNewsBroadcast doctorNewsBroadcast;
    [SerializeField] private SupplyDropAbilitySlot supplyDropAbility;
    [SerializeField] private DoctorSFX doctorSfx;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public Animator anim;
    private SpriteRenderer spR;
    public float vel;
    public float animSwitch;
    private bool ableToMove = true;

    private void Start()
    {
        spR = GetComponent<SpriteRenderer>();
    }

    private void Move()
    {
        Vector2 movementVector2 = new Vector2(playerVelocity.x, playerVelocity.y) * speed * Time.deltaTime;
        transform.Translate(movementVector2);

        if (playerVelocity.x < 0)
        {
            spR.flipX = true;
        }
        else if (playerVelocity.x > 0)
        {
            spR.flipX = false;
        }

        vel = Mathf.Sqrt(Mathf.Pow(movementVector2.x, 2) + Mathf.Pow(movementVector2.y, 2));

        anim.SetFloat("Vel", vel);

        if (playerVelocity.y > movementVector2.y)
        {
            //Debug.Log("up");
            anim.Play("Run");
        }

        if (playerVelocity.y < movementVector2.y)
        {
            //Debug.Log("down");
            anim.Play("Run");
        }

        if (playerVelocity.x < movementVector2.x)
        {
            //Debug.Log("left");
            anim.Play("Run");
        }

        if (playerVelocity.x > movementVector2.x)
        {
            //Debug.Log("right");
            anim.Play("Run");
        }
    }

    private void OnMove(InputValue value)
    {
        playerVelocity = value.Get<Vector2>();
        doctorSfx.PlaySFX(doctorSfx.DoctorRunning);
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
        dab.AdrenalineBoost();
    }

    private void OnAbilityThree()
    {
        sensorPlacer.TryActivate();
    }

    private void OnAbilityFour()
    {
        supplyDropAbility.TryActivate();
    }

    public void canMove()
    {
        ableToMove = true;
    }

    public void notMove()
    {
        ableToMove = false;
    }

    private void FixedUpdate()
    {
        if (ableToMove)
        {
            Move();
        }
    }
}