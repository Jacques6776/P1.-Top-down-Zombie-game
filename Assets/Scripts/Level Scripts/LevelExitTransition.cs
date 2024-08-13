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

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isAtExit = true;
            ExitLevelInteraction();
        }        
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isAtExit = false;
            ExitLevelInteraction();
        }     
    }

    private void ExitLevelInteraction()
    {
        if(isAtExit)
        {
            exitPrompt.enabled = true;
        }
        else if(!isAtExit)//ask about true and false
        {
            exitPrompt.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && isAtExit)
        {
            Debug.Log("Was pressed");
            //LoadNextLevel();
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
