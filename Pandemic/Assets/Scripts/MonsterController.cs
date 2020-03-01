using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 monsterVelocity;

    [SerializeField] private MonsterInfecting infecting;
    [SerializeField] private MonsterNoClip noClip;
    [SerializeField] private MonsterLethalInfecting lethalInfecting;
    [SerializeField] private MonsterUltravision ultravision;
    [SerializeField] private SupplyDropAbilitySlotter supplyDropAbility;

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
            spR.flipX = false;
        }
        else if (monsterVelocity.x > 0)
        {
            spR.flipX = true;
        }

        vel = Mathf.Sqrt(Mathf.Pow(movementVector2.x, 2) + Mathf.Pow(movementVector2.y, 2));

        anim.SetFloat("Vel", vel);
    }

    private void OnMove(InputValue value)
    {
        monsterVelocity = value.Get<Vector2>();
        //Debug.Log($"MonsterVelocity: {monsterVelocity}");
    }

    private void OnAttack()
    {
        infecting.TryInfect();
    }

    private void OnAbilityOne()
    {
        noClip.TryActivate();
    }

    private void OnAbilityTwo()
    {
        lethalInfecting.TryInfect();
    }

    private void OnAbilityThree()
    {
        ultravision.TryActivate();
    }

    private void OnAbilityFour()
    {
        supplyDropAbility.TryActivate();
    }

    private void FixedUpdate()
    {
        Move();
    }
}