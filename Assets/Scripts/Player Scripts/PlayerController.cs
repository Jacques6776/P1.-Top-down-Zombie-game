using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Rotation Controls")]
    Vector2 mouseLook, joystickLook;
    Vector3 rotationTarget;
    public bool isMouseRotation;

    [Header("Movement Controls")]    
    [SerializeField] float walkingMoveSpeed = 5f;
    [SerializeField] float sprintingMoveSpeed = 10f;
    float currentSpeed;
    Vector2 move;

    //private InputAction fire;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }

    public void OnJoystickLook(InputAction.CallbackContext context)
    {
        joystickLook = context.ReadValue<Vector2>();
    }

    //public void Fire(InputAction.CallbackContext context)
    //{
        //Debug.Log("Pew");
    //}

    void Start() 
    {
        currentSpeed = walkingMoveSpeed;
    }

    void Update()
    {
        RotationDetection();
        MoveSpeedSwitch();
    }

    void RotationDetection()
    {
        if(isMouseRotation)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);

            if(Physics.Raycast(ray, out hit))
            {
                rotationTarget = hit.point;
            }

            RotatePlayer();
        }
        else
        {
            if(joystickLook.x == 0 && joystickLook.y == 0)
            {
                MovePlayer();
            }
            else
            {
                RotatePlayer();
            }
        }        
    }

    public void RotatePlayer()
    {
        if(isMouseRotation)
        {
            var lookPos = rotationTarget - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            Vector3 aimDirectionMouse = new Vector3(rotationTarget.x, 0f, rotationTarget.z);

            if(aimDirectionMouse != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
            }
        }
        else
        {
            Vector3 aimDirectionStick = new Vector3(joystickLook.x, 0f, joystickLook.y);

            if(aimDirectionStick != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDirectionStick), 0.15f);
            }
        }
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
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
