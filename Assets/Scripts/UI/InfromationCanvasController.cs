using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfromationCanvasController : MonoBehaviour
{
    [SerializeField] GameObject displayText;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            displayText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            displayText.SetActive(false);//try the destroy version as well
            Destroy(this.gameObject);
        }
    }
}
