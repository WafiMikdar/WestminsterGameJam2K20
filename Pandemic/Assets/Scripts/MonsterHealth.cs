using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour, ICurable
{
    public void Cure(Experience source)
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}