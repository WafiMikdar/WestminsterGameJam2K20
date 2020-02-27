using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBar))]
public class HumanHealth : MonoBehaviour, IInfectable
{
    [SerializeField] private float infectionDuration, incubationDuration, curingDuration;
    private float infectionProgress;

    private HealthBar healthBar;

    private InfectionStatus status = InfectionStatus.Healthy;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    public void Infect()
    {
        switch (status)
        {
            case InfectionStatus.Healthy:
                StartIncubation();
                break;

            case InfectionStatus.Curing:
                StopAllCoroutines();
                healthBar.StopDisplayingBar();
                StartCoroutine(Infecting(infectionDuration));
                break;

            case InfectionStatus.Cured:
                StartIncubation();
                // TODO also slow monster?
                break;
        }
    }

    private void StartIncubation()
    {
        infectionProgress = 0;
        healthBar.DisplayIncubationBar(incubationDuration);
        StartCoroutine(Incubating(incubationDuration));
    }

    private IEnumerator Incubating(float duration)
    {
        status = InfectionStatus.Incubating;
        yield return new WaitForSeconds(duration);
        StartCoroutine(Infecting(infectionDuration));
    }

    private IEnumerator Infecting(float delay)
    {
        status = InfectionStatus.Infected;
        float startTime = Time.time - infectionProgress, endTime = startTime + delay;

        while (Time.time < endTime)
        {
            infectionProgress = Time.time - startTime;
            Debug.Log($"Infection progress: {infectionProgress}");
            yield return null;
        }

        Die();
    }

    public void Cure()
    {
        switch (status)
        {
            case InfectionStatus.Incubating:
                StopAllCoroutines();
                healthBar.StopDisplayingBar();
                status = InfectionStatus.Healthy;
                break;

            case InfectionStatus.Infected:
                StopAllCoroutines();
                healthBar.DisplayCuringBar(curingDuration);
                StartCoroutine(Curing(curingDuration));
                break;
        }
    }

    private IEnumerator Curing(float delay)
    {
        status = InfectionStatus.Curing;
        yield return new WaitForSeconds(delay);
        status = InfectionStatus.Cured;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}