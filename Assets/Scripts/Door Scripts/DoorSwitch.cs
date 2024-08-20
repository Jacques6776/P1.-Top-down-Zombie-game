using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    [SerializeField] DoorController doorController;

    private void OnTriggerEnter(Collider other) 
    {
        doorController.OpenDoor();
    }

    private void OnTriggerExit(Collider other) 
    {
        doorController.CloseDoor();
    }

}
