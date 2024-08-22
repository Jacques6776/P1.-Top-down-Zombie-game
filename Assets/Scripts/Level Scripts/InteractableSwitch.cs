using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableSwitch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactPrompt;
    [SerializeField] bool canInteract;

    [SerializeField] LevelStateChanger levelStateChanger;

    private void Awake() 
    {
        canInteract = false;
        interactPrompt.enabled = false;
    }

    private void Update() 
    {
        StartInteraction();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            canInteract = true;
        }        
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            canInteract = false;
        }     
    }

    private void StartInteraction()
    {
        
        interactPrompt.enabled = canInteract;

        if(canInteract && Input.GetKey(KeyCode.E)) //do fastest check first
        {
            //Debug.Log("Was pressed");
            InteractSequence();
        }
    }

    private void InteractSequence()
    {
        interactPrompt.enabled = false;
        levelStateChanger.AlterState();//call to the level state switch
        Destroy(this.gameObject);
    }
}
