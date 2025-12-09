using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.2f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void LateUpdate()
    {
        float yValue = target.position.y;

        Vector3 current = transform.position;
        Vector3 desired;

        if (yValue >= 3.06f)
        {
            desired = new Vector3(current.x, 4.13f, current.z);
        }
        else
        {
            desired = new Vector3(current.x, originalPosition.y, current.z);
        }

        transform.position = Vector3.Lerp(current, desired, smoothSpeed);
    }
}
