using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsBroadcastHeadline : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    private Vector2 headlinePositionVector2;

    private void LateUpdate()
    {
        headlinePositionVector2.x = camTransform.position.x;
        headlinePositionVector2.y = camTransform.position.y - 2.5f;
        transform.position = headlinePositionVector2;
    }

}
