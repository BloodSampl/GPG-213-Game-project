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
            moveAmount.y = Physics.gravity.y * Time.fixedDeltaTime;
        }
    }

    void Update()
    {
        MovePlayer();
        FacePlayer();
    }
    void MovePlayer()
    {
        float yStore = moveAmount.y;
        moveAmount = new Vector3(Input.GetAxis("Horizontal"), moveAmount.y, Input.GetAxis("Vertical"));
        moveAmount.y = 0f;
        moveAmount = moveAmount.normalized;

        moveAmount.y = yStore;

        charCon.Move(new Vector3(moveAmount.x * playerSpeed,
        moveAmount.y,
        moveAmount.z * playerSpeed) * Time.deltaTime);
        
    }
    void FacePlayer()
    {
        if(moveAmount != Vector3.zero)
        {
            playerBody.transform.forward = new Vector3(moveAmount.x , 0 , moveAmount.z);  // Need to be fixed later.
        }
    }
}
