using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer incubationBar, cureBar;

    [SerializeField] private Transform incubationMaskTransform, curingMaskTransform;

    private InfectionStatus status;

    private float barStartTime, barDuration;

    private void Awake()
    {
        incubationMaskTransform.position = new Vector2(
            incubationBar.transform.position.x - incubationBar.sprite.rect.width * incubationBar.transform.localScale.x / incubationBar.sprite.pixelsPerUnit * 0.5f,
            incubationBar.transform.position.y
        );

        curingMaskTransform.position = new Vector2(
            cureBar.transform.position.x - cureBar.sprite.rect.width * cureBar.transform.localScale.x / cureBar.sprite.pixelsPerUnit * 0.5f,
            cureBar.transform.position.y
        );
    }

    public void DisplayIncubationBar(float duration)
    {
        StopDisplayingBar();
        status = InfectionStatus.Incubating;
        SetBarDuration(duration);
        incubationBar.gameObject.SetActive(true);
    }

    public void DisplayCuringBar(float duration)
    {
        StopDisplayingBar();
        status = InfectionStatus.Curing;
        SetBarDuration(duration);
        cureBar.gameObject.SetActive(true);
    }

    private void SetBarDuration(float duration)
    {
        barStartTime = Time.time;
        barDuration = duration;
    }

    public void StopDisplayingBar()
    {
        status = InfectionStatus.Healthy;
        incubationBar.gameObject.SetActive(false);
        cureBar.gameObject.SetActive(false);
        incubationMaskTransform.transform.localScale = new Vector2(0, incubationMaskTransform.localScale.y);
        curingMaskTransform.transform.localScale = new Vector2(0, curingMaskTransform.localScale.y);
    }

    private void Update()
    {
        switch (status)
        {
            case InfectionStatus.Incubating:
                UpdateBar(incubationMaskTransform);
                break;

            case InfectionStatus.Curing:
                UpdateBar(curingMaskTransform);
                break;
        }
    }

    private void UpdateBar(Transform spriteMaskTransform)
    {
        float progress = (Time.time - barStartTime) / barDuration;
        spriteMaskTransform.localScale = new Vector2(progress * 2, spriteMaskTransform.localScale.y);

        if (progress >= 1)
        {
            status = InfectionStatus.Healthy;
            StopDisplayingBar();
        }
    }
}