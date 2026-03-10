using UnityEngine;

public class CameraPlayerScript : MonoBehaviour
{
    public Transform player;
    public float offsetZ = -10f;

    void LateUpdate()
    {
        // Clamp X between -2 and 19.2
        float clampedX = Mathf.Clamp(player.position.x, -2f, 19.2f);
        // Clamp Y to stay above -2
        float clampedY = Mathf.Max(player.position.y, -2f);

        transform.position = new Vector3(
            clampedX,
            clampedY,
            offsetZ
        );
    }
}
