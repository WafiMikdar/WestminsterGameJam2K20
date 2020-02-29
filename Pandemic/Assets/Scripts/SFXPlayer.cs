using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlaySFX(AudioClip[] clips)
    {
        if (clips.Length > 0)
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"No sound effect for sound from: {gameObject.name} ({gameObject.GetInstanceID()})");
        }
    }
}
