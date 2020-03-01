using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSFX : SFXPlayer
{
    [SerializeField] private HumanMovement humanMovement;

    public AudioClip[] FemaleScream, MaleScream;

    public void PlayScreamSfx()
    {
        if (humanMovement.IsMale == true)
            PlaySFX(MaleScream);
        else
            PlaySFX(FemaleScream);
    }
}
