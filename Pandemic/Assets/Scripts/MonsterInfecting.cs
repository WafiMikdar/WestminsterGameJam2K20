using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class MonsterInfecting : MonoBehaviour
{
    [SerializeField] private float infectionRange;

    private Experience experience;

    private void Awake()
    {
        experience = GetComponent<Experience>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        Infect();
    //    }
    //}

    public void TryInfect()
    {
        Infect();
    }

    private void Infect()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, infectionRange);

        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<IInfectable>()?.Infect(experience);
        }
    }
}