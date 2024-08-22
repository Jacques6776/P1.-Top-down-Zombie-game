using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateChanger : MonoBehaviour
{
    [SerializeField] GameObject[] activateObjects;
    [SerializeField] GameObject[] disableObjects;

    public void AlterState()
    {
        foreach(GameObject toActivace in activateObjects)
        {
            toActivace.SetActive(true);
        }

        foreach(GameObject toDisable in disableObjects)
        {
            toDisable.SetActive(false);
        }
    }
}
