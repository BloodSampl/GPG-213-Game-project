using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    CharacterController charCon;
    [SerializeField] int playerSpeed;
    [SerializeField] GameObject playerBody;
    Vector3 moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if(!charCon.isGrounded)
        {
            moveAmount.y = moveAmount.y + (Physics.gravity.y * Time.deltaTime);
        }
        else
        {
            moveAmount.y = Physics.gravity.y * Time.deltaTime;
        }
    }

    void Update()
    {
        MovePlayer();
        FacePlayer();
    }
    void MovePlayer()
    {
        moveAmount = new Vector3(Input.GetAxis("Horizontal"), moveAmount.y, Input.GetAxis("Vertical"));
        charCon.Move(new Vector3(moveAmount.x * playerSpeed,
        moveAmount.y,
        moveAmount.z * playerSpeed) * Time.deltaTime);
        
    }
    void FacePlayer()
    {
        if(moveAmount != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(moveAmount.normalized);
            playerBody.transform.rotation = rotation;  // Need to be fixed later.
        }
    }
}
