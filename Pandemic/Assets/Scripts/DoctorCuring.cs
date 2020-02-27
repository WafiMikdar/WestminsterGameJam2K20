using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class DoctorCuring : MonoBehaviour
{
    [SerializeField] private float cureRadius;

    private Experience experience;

    private void Awake()
    {
        experience = GetComponent<Experience>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cure();
        }
    }

    private void Cure()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, cureRadius);

        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<IInfectable>()?.Cure(experience);
        }
    }
}