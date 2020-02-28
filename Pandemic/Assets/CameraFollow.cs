using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothspeed;
    [SerializeField] private Vector3 offset;
    Vector3 velocityVector3 = new Vector3(0.0f, 0.0f, 0.0f);

    private void LateUpdate ()
    {
        Vector3 chosenPositionVector3 = player.position + offset;
        //Vector3 playerPosVector3 = player.position;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, chosenPositionVector3, smoothspeed*Time.deltaTime);
        //Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, chosenPositionVector3, 
        //ref playerPosVector3, smoothspeed*Time.deltaTime, maxSpeed);
        transform.position = smoothPosition;
    }
}
