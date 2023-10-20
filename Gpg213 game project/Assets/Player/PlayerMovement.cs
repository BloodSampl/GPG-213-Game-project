using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    CharacterController charCon;
    [SerializeField] float playerSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject playerBody;
    Vector3 moveInput;
    Vector3 facingDirection;

    Transform cam;
    // Start is called before the first frame update

    private void Awake()
    {
        cam = Camera.main.transform;
        charCon = GetComponent<CharacterController>();
    }
    void Start()
    {

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
        FaceDirection();

    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveInput = new Vector3(horizontalInput, moveInput.y, verticalInput);
        float magnitude = Mathf.Clamp01(moveInput.magnitude) * playerSpeed;


        moveInput = Quaternion.AngleAxis(cam.rotation.eulerAngles.y, Vector3.up) * moveInput;
        moveInput.Normalize();

        charCon.Move(moveInput * magnitude * Time.deltaTime);
    }
    void FaceDirection()
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
    }
}
