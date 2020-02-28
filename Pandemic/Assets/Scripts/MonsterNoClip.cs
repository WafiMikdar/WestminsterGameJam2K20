using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MonsterNoClip : MonoBehaviour
{
    [SerializeField] private float cooldown, duration;
    private float readyTime;

    [SerializeField] private string buildingLayerName;

    public void TryActivate()
    {
        if (Time.time >= readyTime)
        {
            readyTime = Time.time + cooldown;
            StartCoroutine(NoClipping());
        }
    }

    private IEnumerator NoClipping()
    {
        int buildingLayer = LayerMask.NameToLayer(buildingLayerName);
        Physics2D.IgnoreLayerCollision(buildingLayer, gameObject.layer, true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreLayerCollision(buildingLayer, gameObject.layer, false);
    }
}

// Can be used for custom shunting when no clip ends. Unity physics seem to do a fine job though
//Collider2D[] overlaps = new Collider2D[10];
//if (coll.GetContacts(overlaps) > 0)
//{
//    foreach (Collider2D overlap in overlaps)
//    {
//        if (overlap.gameObject.layer == buildingLayer)
//        {
//            Vector2 closestPoint = overlap.ClosestPoint(transform.position);
//            transform.position = closestPoint + (closestPoint - (Vector2)transform.position).normalized * coll.bounds.extents.x * transform.localScale.x;
//            break;
//        }
//    }
//}