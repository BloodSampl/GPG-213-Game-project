using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController charCon;
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] float mouseVerticalSpeed = 2.0f;
    [SerializeField] float mouseHorizontalSpeed = 2.0f;
    [SerializeField] GameObject playerBody;
    [SerializeField] Transform lookPoint;
    float verticalRotStore;
    Vector3 moveInput;
    Camera cam;

    private Vector3 velocity;
    private float gravity = -9.81f;

    private void Awake()
    {
        cam = Camera.main;
        charCon = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();
        LookCamera();
    }

    private void LateUpdate()
    {
        cam.transform.position = lookPoint.position;
        cam.transform.rotation = lookPoint.rotation;
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(horizontalInput, 0, verticalInput);
        moveInput.Normalize();

        Vector3 moveDirection = transform.TransformDirection(moveInput);
        velocity.y += gravity * Time.deltaTime;
        charCon.Move((velocity + moveDirection * playerSpeed) * Time.deltaTime);
    }

    void LookCamera()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + mouseX * mouseHorizontalSpeed,
            transform.rotation.eulerAngles.z);

        verticalRotStore -= mouseY * mouseVerticalSpeed;
        verticalRotStore = Mathf.Clamp(verticalRotStore, -80, 80);

        lookPoint.rotation = Quaternion.Euler(verticalRotStore,
            lookPoint.rotation.eulerAngles.y,
            lookPoint.rotation.eulerAngles.z);
    }
}