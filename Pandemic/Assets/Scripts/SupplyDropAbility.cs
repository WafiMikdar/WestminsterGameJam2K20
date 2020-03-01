using UnityEngine;

public abstract class SupplyDropAbility : MonoBehaviour
{
    public void AttachTo(SupplyDropAbilitySlotter newSlotter)
    {
        SupplyDropAbility newAbility = Instantiate(gameObject, newSlotter.transform.position, Quaternion.identity, newSlotter.transform).GetComponent<SupplyDropAbility>();
        newSlotter.ReplaceCurrentAbility(newAbility);
        //return newAbility;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    public abstract void TryActivate();

    public abstract void Activate();
}