using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float cameraSpeed = 5f;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.fixedDeltaTime * cameraSpeed);
    }
}
