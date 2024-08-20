using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    
    [SerializeField] Transform closedPosition;
    [SerializeField] Transform openPosition;
    [SerializeField] float moveSpeed;
    [SerializeField] bool openDoor = false;
        
    void Update()
    {
        if(openDoor)
        {
            float move = moveSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, openPosition.position, move);
        }

        if(!openDoor)
        {
            float move = moveSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, closedPosition.position, move);
        }
    }

    public void OpenDoor()
    {
        openDoor = true;
    }

    public void CloseDoor()
    {
        openDoor = false;
    }
    
}
