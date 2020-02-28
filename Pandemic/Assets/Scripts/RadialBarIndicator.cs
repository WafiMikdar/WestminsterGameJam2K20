using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialBarIndicator : MonoBehaviour
{
    [SerializeField] private GameObject radialBarPrefab;

    [SerializeField] private Transform canvas;

    [SerializeField] private AnimationCurve alphaCurve;

    public void SetIndicator(float angle, float variance, float duration, Color color)
    {
        Image radialBar = Instantiate(radialBarPrefab, transform.position, Quaternion.identity, canvas).transform.GetChild(0).GetComponent<Image>();
        radialBar.color = color;
        float centerAngle = angle + Random.Range(0, variance);
        radialBar.fillAmount = variance / 360f;
        radialBar.transform.parent.rotation = Quaternion.Euler(0, 0, centerAngle);
        StartCoroutine(DeactivatingIndicator(radialBar, duration));
    }

    private IEnumerator DeactivatingIndicator(Image radialBar, float duration)
    {
        float startTime = Time.time, endTime = startTime + duration;

        while (endTime > Time.time)
        {
            radialBar.color = new Color(radialBar.color.r, radialBar.color.g, radialBar.color.b,
                                        alphaCurve.Evaluate((Time.time - startTime) / duration));
            yield return null;
        }

        Destroy(radialBar.transform.parent.gameObject);
    }
}