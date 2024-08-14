using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitTransition : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI exitPrompt;
    [SerializeField] bool isAtExit;

    private void Awake() 
    {
        isAtExit = false;
        exitPrompt.enabled = false;
    }

    private void Update() 
    {
        ExitLevelInteraction();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isAtExit = true;
        }        
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isAtExit = false;
        }     
    }

    private void ExitLevelInteraction()
    {
        
        exitPrompt.enabled = isAtExit;

        if(isAtExit && Input.GetKey(KeyCode.E)) //do fastest check first
        {
            //Debug.Log("Was pressed");
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
