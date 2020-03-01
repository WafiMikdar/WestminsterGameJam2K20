using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class UnlockableCooldownAbility : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float readyTime;

    [SerializeField] private Image padlock, litImage;

    private bool locked = true;

    public bool IsReady => Time.time >= readyTime && !locked;

    public void Unlock()
    {
        padlock.gameObject.SetActive(false);
        litImage.fillAmount = 1;
        readyTime = Time.time;
        locked = false;
    }

    public void ResetCooldown()
    {
        readyTime = Time.time + cooldown;
        StartCoroutine(FillingLitImage());
    }

    private IEnumerator FillingLitImage()
    {
        float startTime = Time.time, totalTime = readyTime - startTime;

        while (readyTime > Time.time)
        {
            litImage.fillAmount = (Time.time - startTime) / totalTime;
            yield return null;
        }

        litImage.fillAmount = 1;
    }
}