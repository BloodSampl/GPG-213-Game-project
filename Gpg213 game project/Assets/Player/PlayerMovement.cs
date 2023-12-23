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
    bool controllsLocked = true;
    [SerializeField] GameObject[] objectsToDisable; 
    [SerializeField] GameObject[] objectsToEnable; 

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
        if (Input.GetKeyDown(KeyCode.Tab) && controllsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            foreach (GameObject go in objectsToDisable)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in objectsToEnable)
            {
                go.SetActive(true);
            }
            controllsLocked = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !controllsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            foreach (GameObject go in objectsToDisable)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in objectsToEnable)
            {
                go.SetActive(false);
            }
            controllsLocked = true;
        }
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            MovePlayer();
        }
        
            LookCamera();
    }

    private void LateUpdate()
    {
        if (cam == null) cam = Camera.main;

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