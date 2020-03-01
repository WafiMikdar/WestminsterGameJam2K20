using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorAirStrike : SupplyDropAbility
{
    [SerializeField] private GameObject indicator;

    [SerializeField] private ParticleSystem horizontalParticles, verticalParticles;

    [SerializeField] private Vector2 size, tileSize;

    [SerializeField] private float warningDuration, minIndicatorAlpha, maxIndicatorAlpha, frequencyModifierFactor, frequencyModifierExponent;

    public override void TryActivate()
    {
        Activate();
    }

    public override void Activate()
    {
        Vector2 intersection = GetNearestTileIntersection();
        SpriteRenderer horizontalRend = Instantiate(indicator, intersection, Quaternion.Euler(0, 0, 90)).GetComponent<SpriteRenderer>();
        SpriteRenderer verticalRend = Instantiate(indicator, intersection, Quaternion.identity).GetComponent<SpriteRenderer>();

        horizontalParticles.transform.position = intersection;
        verticalParticles.transform.position = intersection;
        horizontalRend.size = size;
        verticalRend.size = size;

        StartCoroutine(FlashingWarningZone(horizontalRend, verticalRend));
    }

    private Vector2 GetNearestTileIntersection() => new Vector2((int)(transform.position.x / tileSize.x) * tileSize.x,
                                                                (int)(transform.position.y / tileSize.y) * tileSize.y);

    private IEnumerator FlashingWarningZone(SpriteRenderer horizontalRend, SpriteRenderer verticalRend)
    {
        float startTime = Time.time, endTime = startTime + warningDuration;

        while (endTime > Time.time)
        {
            float alpha = GetIndicatorAlpha(startTime);
            horizontalRend.color = new Color(horizontalRend.color.r, horizontalRend.color.g, horizontalRend.color.b, alpha);
            verticalRend.color = new Color(verticalRend.color.r, verticalRend.color.g, verticalRend.color.b, alpha);
            yield return null;
        }

        Destroy(horizontalRend.gameObject);
        Destroy(verticalRend.gameObject);
        horizontalParticles.Play(true);
        verticalParticles.Play(true);
    }

    private float GetIndicatorAlpha(float startTime)
    {
        float elapsed = Time.time - startTime;
        float sin = Mathf.Sin(elapsed + frequencyModifierFactor * Mathf.Pow(elapsed, frequencyModifierExponent));
        return Mathf.Lerp(minIndicatorAlpha, maxIndicatorAlpha, sin * 0.5f + 0.5f);
    }
}