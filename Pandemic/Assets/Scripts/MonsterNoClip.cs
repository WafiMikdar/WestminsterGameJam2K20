using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MonsterNoClip : UnlockableCooldownAbility
{
    [SerializeField] private float duration;

    [SerializeField] private string buildingLayerName;

    private Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        Unlock();
    }

    public void TryActivate()
    {
        if (IsReady)
        {
            StartCoroutine(NoClipping());
            ResetCooldown();
        }
    }

    private IEnumerator NoClipping()
    {
        int buildingLayer = LayerMask.NameToLayer(buildingLayerName);
        Physics2D.IgnoreLayerCollision(buildingLayer, gameObject.layer, true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreLayerCollision(buildingLayer, gameObject.layer, false);

        ShuntOutOfBuildings(buildingLayer);
    }

    private void ShuntOutOfBuildings(int buildingLayer)
    {
        float range = 1;
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 checkPos = (Vector2)transform.position + GetCheckPos(range, i);
                Collider2D[] overlaps = Physics2D.OverlapCircleAll(checkPos, 0.3f).Where(c => c.gameObject.layer == buildingLayer).ToArray();

                if (overlaps.Length == 0)
                {
                    transform.position = checkPos;
                    return;
                }
            }

            range += 1;

            if (range > 100)
            {
                return;
            }
        }
    }

    private Vector2 GetCheckPos(float range, int quadrant)
    {
        switch (quadrant)
        {
            case 0:
                return new Vector2(range, 0);

            case 1:
                return new Vector2(-range, 0);

            case 2:
                return new Vector2(0, range);

            case 3:
                return new Vector2(0, -range);
        }

        return Vector2.zero;
    }
}

// Can be used for custom shunting when no clip ends. Unity physics seem to do a fine job though