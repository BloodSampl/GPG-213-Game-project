using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController charCon;
    [SerializeField] float playerSpeed;
    [SerializeField] float mouseVerticlSpeed;
    [SerializeField] float mouseHorizontalSpeed;
    //[SerializeField] float rotateSpeed;
    [SerializeField] GameObject playerBody;
    [SerializeField] Transform lookPoint;
    float verticlalRotStore;
    Vector3 moveInput;
    Vector3 facingDirection;

    Camera cam;
    // Start is called before the first frame update

    private void Awake()
    {
        cam = Camera.main;
        charCon = GetComponent<CharacterController>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        
    }

    private void FixedUpdate()
    {
        if(!charCon.isGrounded)
        {
            moveInput.y =+ moveInput.y + (Physics.gravity.y * Time.deltaTime);
        }
        else
        {
            moveInput.y = Physics.gravity.y * Time.fixedDeltaTime;
        }
    }

    void Update()
    {
        MovePlayer();
        //FaceDirection();
        LookCamera();
    }
    private void LateUpdate()
    {
        cam.transform.position = lookPoint.position;
        cam.transform.rotation = lookPoint.rotation;
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveInput = new Vector3(horizontalInput, moveInput.y, verticalInput);
        float magnitude = Mathf.Clamp01(moveInput.magnitude) * playerSpeed;


        Vector3 movement = (transform.forward * moveInput.z) + (transform.right * moveInput.x);
        moveInput.Normalize();

        charCon.Move(movement * magnitude * Time.deltaTime);
    }
    void LookCamera()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + mouseX * mouseHorizontalSpeed ,
            transform.rotation.eulerAngles.z);

        verticlalRotStore += mouseY * mouseVerticlSpeed;
        verticlalRotStore = Mathf.Clamp(verticlalRotStore, -50,40);

        lookPoint.rotation = Quaternion.Euler(-verticlalRotStore,
            lookPoint.rotation.eulerAngles.y,
            lookPoint.rotation.eulerAngles.z);
    }
    /*void FaceDirection()
    {
        if (moveInput != Vector3.zero)
        {
            Vector3 targetDirection = new Vector3(moveInput.x, 0, moveInput.z);
            if (targetDirection.magnitude > 0.001f)
            {
                Quaternion rotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            }
        }
    }*/
}
