using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class DoctorAirStrike : SupplyDropAbility
{
    [SerializeField] private GameObject indicator;

    [SerializeField] private Sprite dangerSprite;

    [SerializeField] private ParticleSystem horizontalParticles, verticalParticles;

    [SerializeField] private Vector2 size, tileSize;

    [SerializeField] private float warningDuration, dangerDuration, minIndicatorAlpha, maxIndicatorAlpha, baseFrequencyModifier, frequencyModifierFactor, frequencyModifierExponent;

    [SerializeField] private uint usesLeft = 1;

    private Experience experience;

    private void Awake()
    {
        experience = GetComponent<Experience>();
        Activate();
    }

    public override void TryActivate()
    {
        if (usesLeft > 0)
        {
            Activate();
            usesLeft--;
        }
    }

    public override void Activate()
    {
        Vector2 intersection = GetNearestTileIntersection();
        SpriteRenderer horizontalRend = Instantiate(indicator, intersection, Quaternion.Euler(0, 0, 0)).GetComponent<SpriteRenderer>();
        SpriteRenderer verticalRend = Instantiate(indicator, intersection, Quaternion.identity).GetComponent<SpriteRenderer>();

        horizontalParticles.transform.position = intersection;
        verticalParticles.transform.position = intersection;
        horizontalRend.size = size;
        verticalRend.size = new Vector2(size.y, size.x);

        StartCoroutine(FlashingWarningZone(horizontalRend, verticalRend));
    }

    private Vector2 GetNearestTileIntersection() => new Vector2(Mathf.RoundToInt(transform.position.x / tileSize.x) * tileSize.x,
                                                                Mathf.RoundToInt(transform.position.y / tileSize.y) * tileSize.y);

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

        StartCoroutine(WarningZone(horizontalRend, verticalRend));
    }

    private float GetIndicatorAlpha(float startTime)
    {
        float elapsed = Time.time - startTime;
        float sin = Mathf.Sin(baseFrequencyModifier * elapsed + frequencyModifierFactor * Mathf.Pow(elapsed, frequencyModifierExponent));
        return Mathf.Lerp(minIndicatorAlpha, maxIndicatorAlpha, sin * 0.5f + 0.5f);
    }

    private IEnumerator WarningZone(SpriteRenderer horizontalRend, SpriteRenderer verticalRend)
    {
        horizontalRend.sprite = dangerSprite;
        verticalRend.sprite = dangerSprite;

        yield return new WaitForSeconds(dangerDuration);

        CureInStrikeZone(horizontalRend, verticalRend);

        Destroy(horizontalRend.gameObject);
        Destroy(verticalRend.gameObject);
        horizontalParticles?.Play(true);
        verticalParticles?.Play(true);
    }

    private void CureInStrikeZone(SpriteRenderer horizontalRend, SpriteRenderer verticalRend)
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(verticalRend.transform.position, verticalRend.size, 0).Union(
            Physics2D.OverlapBoxAll(horizontalRend.transform.position, horizontalRend.size, 0)).ToArray();

        foreach (Collider2D coll in colls)
        {
            coll.GetComponent<ICurable>()?.Cure(experience);
        }
    }
}