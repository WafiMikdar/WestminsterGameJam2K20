using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyDropAbilitySlot : MonoBehaviour
{
    [SerializeField] private bool isDoctor;

    [SerializeField] private Image imageMask;

    private SupplyDropAbility currentAbility;

    public void ReplaceCurrentAbility(SupplyDropAbility newAbility)
    {
        currentAbility?.Remove();
        currentAbility = newAbility;
        imageMask.fillAmount = 1;
    }

    public void TryActivate()
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