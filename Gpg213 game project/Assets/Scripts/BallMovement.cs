using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Ensure a Rigidbody component is attached
public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f; // Adjust the rotation speed here

    private Rigidbody rb;
    private Vector3 targetDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Freeze rotation to prevent unwanted rotations
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movement.magnitude >= 0.1f) // Check if there's actual movement
        {
            targetDirection = Quaternion.LookRotation(movement).eulerAngles;
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.Euler(0, targetDirection.y, 0), rotationSpeed * Time.fixedDeltaTime));
        }

        rb.velocity = movement * moveSpeed; // Apply physics-based movement
    }
}
