using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivation : MonoBehaviour
{
    [SerializeField] GameObject objectForActivation;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            objectForActivation.SetActive(true);
            Destroy(this.gameObject);
        }
    }

}
