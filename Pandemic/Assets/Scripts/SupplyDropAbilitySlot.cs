using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyDropAbilitySlot : MonoBehaviour
{
    [SerializeField] private bool isDoctor;

    [SerializeField] private Image imageMask;

    [SerializeField] private FadingNotification notifier;

    private SupplyDropAbility currentAbility;

    public void ReplaceCurrentAbility(SupplyDropAbility newAbility)
    {
        currentAbility?.Remove();
        currentAbility = newAbility;
        imageMask.fillAmount = 1;

        switch (newAbility)
        {
            case MonsterWallPlacer ability:
                notifier.CreateNotification("Got web wall, press X to place a wall between nearest buildings");
                break;

            case DoctorAirStrike ability:
                notifier.CreateNotification("Got air strike, press ; to air drop curing rain");
                break;

            case MonsterEcholocation ability:
                notifier.CreateNotification("Got echolocation, press X to see which direction the doctor is");
                break;

            case DoctorNewsBroadcast ability:
                notifier.CreateNotification("Got news broadcast, press ; to see a preview of where the monster is");
                break;
        }
    }

    public virtual void TryActivate()
    {
        currentAbility?.TryActivate();
        imageMask.fillAmount = 0;
    }

    public void Activate()
    {
        currentAbility?.Activate();
        imageMask.fillAmount = 0;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SupplyDrop"))
        {
            PickUpSupplyDrop(other.gameObject.GetComponent<SupplyDrop>());
        }
    }

    protected virtual void PickUpSupplyDrop(SupplyDrop drop)
    {
        if (isDoctor)
        {
            drop.DoctorAbility.AttachTo(this);
        }
        else
        {
            drop.MonsterAbility.AttachTo(this);
        }

        drop.Remove();
    }
}