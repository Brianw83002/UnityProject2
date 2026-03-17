using UnityEngine;

public class CameraPlayerScript : MonoBehaviour
{
    public Transform player;
    public float offsetZ = -10f;

    public float offsetX_min;
    public float offsetX_max;

    public float offsetY_min;
    public float offsetY_max;
    void LateUpdate()
    {
        // Clamp X between -2 and 19.2
        float clampedX = Mathf.Clamp(player.position.x, offsetX_min, offsetX_max);
        // Clamp Y to stay above -2
        float clampedY = Mathf.Clamp(player.position.y, offsetY_min, offsetY_max);

        transform.position = new Vector3(
            clampedX,
            clampedY,
            offsetZ
        );
    }
}
