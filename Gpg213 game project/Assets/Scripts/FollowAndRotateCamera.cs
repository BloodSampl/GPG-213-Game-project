using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndRotateCamera : MonoBehaviour
{
    public Transform objectToFollow;
    public float followSpeed = 5f;
    public float mouseSensitivity = 2f;

    public float stableHeight = 2f; // Stabilized height

    public Vector3 offsetFromObject = new Vector3(0f, 0f, -5f); // Adjust horizontal offset here

    void Update()
    {
        // Camera follow the specified object with offset
        if (objectToFollow != null)
        {
            Vector3 desiredPosition = objectToFollow.position +
                                       objectToFollow.TransformDirection(offsetFromObject);

            // Stabilize the camera height
            desiredPosition.y = stableHeight;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            transform.LookAt(objectToFollow);
        }

        // Mouse look for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up, mouseX);
        transform.Rotate(Vector3.left, mouseY);
    }
}
