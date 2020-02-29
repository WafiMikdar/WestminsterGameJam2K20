using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyDropAbilitySlot : MonoBehaviour
{
    [SerializeField] private bool isDoctor;

    private SupplyDropAbility currentAbility;

    public void ReplaceCurrentAbility(SupplyDropAbility newAbility)
    {
        currentAbility?.Remove();
        currentAbility = newAbility;
    }

    public void TryActivate()
    {
        currentAbility?.TryActivate();
    }

    public void Activate()
    {
        currentAbility?.TryActivate();
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