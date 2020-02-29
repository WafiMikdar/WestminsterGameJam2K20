using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBar))]
public class HumanHealth : MonoBehaviour, IInfectable, ICurable
{
    [SerializeField] private float infectionDuration, incubationDuration, curingDuration;
    private float infectionProgress, incubationProgress;

    [SerializeField] private double infectionXPGain, cureXPLoss, cureXPGain;

    private HealthBar healthBar;

    private Experience experienceTarget;

    private InfectionStatus status = InfectionStatus.Healthy;
    public InfectionStatus Status => status;
    public bool IsHealthy => status == InfectionStatus.Healthy || status == InfectionStatus.Cured;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    public void Infect(Experience source, float duration = -1)
    {
        experienceTarget = source;

        float infectionDuration = Math.Abs(duration - (-1)) < 0.01f ? this.infectionDuration : duration;

        switch (status)
        {
            case InfectionStatus.Healthy:
                StartIncubation(incubationDuration, infectionDuration);
                break;

            case InfectionStatus.Curing:
                experienceTarget.AwardXP(infectionXPGain);
                StopAllCoroutines();
                healthBar.StopDisplayingBar();
                StartCoroutine(Infecting(infectionDuration));
                break;

            case InfectionStatus.Cured:
                StartIncubation(incubationDuration, infectionDuration);
                // TODO also slow monster?
                break;
        }
    }

    private void StartIncubation(float incubationDuration, float infectionDuration)
    {
        infectionProgress = 0;
        healthBar.DisplayIncubationBar(incubationDuration);
        StartCoroutine(Incubating(incubationDuration, infectionDuration));
    }

    private IEnumerator Incubating(float duration, float infectionDuration)
    {
        status = InfectionStatus.Incubating;
        float startTime = Time.time, endTime = startTime + duration;

        while (endTime > Time.time)
        {
            experienceTarget.AwardXP(((Time.time - startTime) - incubationProgress) / incubationDuration * infectionXPGain);
            incubationProgress = Time.time - startTime;
            yield return null;
        }

        experienceTarget.AwardXP((incubationDuration - incubationProgress) * infectionXPGain);
        StartCoroutine(Infecting(infectionDuration));
    }

    private IEnumerator Infecting(float delay)
    {
        status = InfectionStatus.Infected;
        float startTime = Time.time - infectionProgress, endTime = startTime + delay;

        while (Time.time < endTime)
        {
            infectionProgress = Time.time - startTime;
            //Debug.Log($"Infection progress: {infectionProgress}");
            yield return null;
        }

        Die();
    }

    public void Cure(Experience source)
    {
        experienceTarget = source;

        switch (status)
        {
            case InfectionStatus.Incubating:
                experienceTarget.AwardXP(incubationProgress / incubationDuration * -infectionXPGain);
                StopAllCoroutines();
                healthBar.StopDisplayingBar();
                status = InfectionStatus.Healthy;
                experienceTarget.AwardXP(cureXPGain);
                break;

            case InfectionStatus.Infected:
                StopAllCoroutines();
                healthBar.DisplayCuringBar(curingDuration);
                StartCoroutine(Curing(curingDuration));
                break;
        }
    }

    private IEnumerator Curing(float duration)
    {
        status = InfectionStatus.Curing;
        float startTime = Time.time, endTime = startTime + duration, curingProgress = 0;

        while (endTime > Time.time)
        {
            experienceTarget.AwardXP(((Time.time - startTime) - curingProgress) / curingDuration * -cureXPLoss);
            curingProgress = Time.time - startTime;
            yield return null;
        }

        experienceTarget.AwardXP(cureXPGain);
        status = InfectionStatus.Cured;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}