using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience), typeof(Animator))]
public class DoctorCuring : UnlockableCooldownAbility
{
    [SerializeField] private float cureRadius;
    [SerializeField] private DoctorSFX doctorSfx;

    [SerializeField] private ParticleSystem particles;

    private Animator anim;
    private Experience experience;

    private void Awake()
    {
        experience = GetComponent<Experience>();
        anim = GetComponent<Animator>();
        Unlock();
    }

    public void TryCure()
    {
        if (IsReady)
        {
            doctorSfx.PlaySFX(doctorSfx.DoctorInject);
            Cure();
            ResetCooldown();
            anim.Play("Cure");
        }
    }

    private void Cure()
    {
        particles.Play(true);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, cureRadius);

        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<ICurable>()?.Cure(experience);
        }
    }
}