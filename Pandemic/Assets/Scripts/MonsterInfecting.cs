using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfecting : MonoBehaviour
{
    [SerializeField] private float infectionRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Infect();
        }
    }

    private void Infect()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, infectionRange);

        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<IInfectable>()?.Infect();
        }
    }
}