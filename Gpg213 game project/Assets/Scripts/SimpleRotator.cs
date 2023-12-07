using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation (default is around Y axis)

    void Update()
    {
        // Rotate the object around the specified axis at a constant speed
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
