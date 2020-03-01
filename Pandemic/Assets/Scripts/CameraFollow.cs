using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;
    Vector3 velocityVector3 = new Vector3(0.0f, 0.0f, 0.0f);

    private void LateUpdate ()
    {
        Vector3 chosenPositionVector3 = player.position + offset;
        Vector3 smoothPosition = Vector3.Slerp(transform.position, chosenPositionVector3, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
