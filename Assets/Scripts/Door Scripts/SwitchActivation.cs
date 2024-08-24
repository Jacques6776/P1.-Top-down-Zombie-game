using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivation : MonoBehaviour
{
    [SerializeField] GameObject[] objectForActivation;
    
    private void OnTriggerEnter(Collider other) 
    {
        foreach(GameObject toActivace in objectForActivation)
        {
            toActivace.SetActive(true);
        }
    }

}
