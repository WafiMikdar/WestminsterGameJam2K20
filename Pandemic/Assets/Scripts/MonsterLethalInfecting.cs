using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLethalInfecting : MonsterInfecting
{
    protected override void Infect()
    {
        infectionParticles.Play(true);
        ForEachNearbyInfectable(infectable => infectable.Infect(experience, 0));
    }
}