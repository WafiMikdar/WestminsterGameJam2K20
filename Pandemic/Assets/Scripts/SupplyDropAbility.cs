using UnityEngine;

public abstract class SupplyDropAbility : MonoBehaviour
{
    public void AttachTo(SupplyDropAbilitySlot newSlot)
    {
        SupplyDropAbility newAbility = Instantiate(gameObject, newSlot.transform.position, Quaternion.identity, newSlot.transform).GetComponent<SupplyDropAbility>();
        newSlot.ReplaceCurrentAbility(newAbility);
        //return newAbility;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    public abstract void TryActivate();

    public abstract void Activate();
}