using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingNotification : MonoBehaviour
{
    [SerializeField] private GameObject notificationPanel;

    [SerializeField] private Graphic[] fadingObjects;

    [SerializeField] private Text notificationText;

    [SerializeField] private float opaqueDuration, fadeDuration;

    public void CreateNotification(string text)
    {
        CancelInvoke();
        StopAllCoroutines();

        notificationPanel.SetActive(true);
        notificationText.text = text;

        Invoke("StartFading", opaqueDuration);
    }

    private void StartFading()
    {
        StartCoroutine(FadingCurrentNotification());
    }

    private IEnumerator FadingCurrentNotification()
    {
        float startTime = Time.time, endTime = startTime + fadeDuration;

        while (endTime > Time.time)
        {
            foreach (Graphic graphic in fadingObjects)
            {
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, 1 - (Time.time - startTime) / fadeDuration);
            }

            yield return null;
        }

        foreach (Graphic graphic in fadingObjects)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, 1);
        }

        notificationPanel.SetActive(false);
    }
}