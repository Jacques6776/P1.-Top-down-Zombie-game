using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class RoomPlateController : MonoBehaviour
{
    [SerializeField] GameObject roomPlate;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            roomPlate.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            roomPlate.SetActive(true);
        }
    }
}
