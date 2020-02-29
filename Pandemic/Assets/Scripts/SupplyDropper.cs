using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SupplyDropper : MonoBehaviour
{
    [SerializeField] private Transform lowerLeftBound, upperRightBound;

    [SerializeField] private float dropInterval, dropClearanceRadius;

    [SerializeField] private GameObject drop;

    [SerializeField] private LayerMask blocksDrop;

    [SerializeField] private Transform supplyDropAbilities;

    private List<SupplyDropAbility> doctorAbilities = new List<SupplyDropAbility>(), monsterAbilities = new List<SupplyDropAbility>();

    private void Awake()
    {
        doctorAbilities = supplyDropAbilities.GetChild(0).GetComponentsInChildren<Transform>().Skip(1).Select(t => t.GetComponent<SupplyDropAbility>()).Where(a => a != null).ToList();
        monsterAbilities = supplyDropAbilities.GetChild(1).GetComponentsInChildren<Transform>().Skip(1).Select(t => t.GetComponent<SupplyDropAbility>()).Where(a => a != null).ToList();
        InvokeRepeating("DropSupply", dropInterval, dropInterval);
    }

    private void DropSupply()
    {
        SupplyDrop newDrop = Instantiate(drop, GetValidDropPos(), Quaternion.identity).GetComponent<SupplyDrop>();
        SetDropAbilities(newDrop);
    }

    private Vector2 GetValidDropPos()
    {
        Vector2 testPos;
        do
        {
            testPos = GetRandomPosInBounds();
        } while (IsOverlappingBuildings(testPos));

        return testPos;
    }

    private Vector2 GetRandomPosInBounds() => new Vector2(
        Random.Range(lowerLeftBound.position.x, upperRightBound.position.x),
        Random.Range(lowerLeftBound.position.y, upperRightBound.position.y));

    private bool IsOverlappingBuildings(Vector2 testPos) => Physics2D.OverlapCircle(testPos, dropClearanceRadius, blocksDrop);

    private void SetDropAbilities(SupplyDrop newDrop)
    {
        newDrop.DoctorAbility = doctorAbilities[Random.Range(0, doctorAbilities.Count)];
        newDrop.MonsterAbility = monsterAbilities[Random.Range(0, monsterAbilities.Count)];
    }
}