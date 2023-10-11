using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] int _playerSpeed;
    [SerializeField] GameObject _playerBody;
    Vector3 _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        // make gravity for the player
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FacePlayer();
    }
    void MovePlayer()
    {
        _playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(new Vector3(_playerInput.x * _playerSpeed,
        0,
        _playerInput.z * _playerSpeed) * Time.deltaTime);
        
    }
    void FacePlayer()
    {
        if(_playerInput != Vector3.zero)
        {
            _playerBody.transform.forward = Vector3.Normalize(_playerInput);  // Need to be fixed later.
        }
    }
}
