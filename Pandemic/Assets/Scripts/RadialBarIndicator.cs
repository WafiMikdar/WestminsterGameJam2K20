using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialBarIndicator : MonoBehaviour
{
    [SerializeField] private Image radialBar;

    [SerializeField] private AnimationCurve alphaCurve;

    [SerializeField] private float fadeDuration;

    public void SetIndicator(float angle, float variation)
    {
        float centerAngle = angle + Random.Range(0, variation);
        radialBar.fillAmount = variation / 360f;
        radialBar.transform.parent.rotation = Quaternion.Euler(0, 0, centerAngle);
        radialBar.transform.parent.gameObject.SetActive(true);
        StartCoroutine(DeactivatingIndicator());
    }

    private IEnumerator DeactivatingIndicator()
    {
        float startTime = Time.time, endTime = startTime + fadeDuration;

        while (endTime > Time.time)
        {
            radialBar.color = new Color(radialBar.color.r, radialBar.color.g, radialBar.color.b,
                                        alphaCurve.Evaluate((Time.time - startTime) / fadeDuration));
            yield return null;
        }

        radialBar.transform.parent.gameObject.SetActive(false);
    }
}