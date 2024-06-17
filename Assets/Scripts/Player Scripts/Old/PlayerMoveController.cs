using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMoveController : MonoBehaviour
{
    
    //[SerializeField] GameObject playerMover;
    //[SerializeField] GameObject playerRotator;
    Camera mainCamera;

    Rigidbody playerRb;
    Vector3 moveInput;
    Vector3 moveVelocity;
    
    [Header("Movement Settings")]
    [SerializeField] float walkingMoveSpeed = 5f;
    [SerializeField] float sprintingMoveSpeed = 10f;
    float currentSpeed;
    
    void Start() 
    {
        mainCamera = FindObjectOfType<Camera>();
        playerRb = GetComponent<Rigidbody>();
        currentSpeed = walkingMoveSpeed;
    }

    void Update()
    {        
        MovePlayer();
        RotatePlayer();
        MoveSpeedSwitch();
    }

    void FixedUpdate()
    {
        playerRb.velocity = moveVelocity;
    } 

    void MovePlayer()
    {         
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        //look into means of improving gampead inputs - not really using the new input system: look to upgrade
        moveVelocity = moveInput * currentSpeed;
    }

    void RotatePlayer()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);           
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void MoveSpeedSwitch()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = sprintingMoveSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkingMoveSpeed;
        }        
    }
}
