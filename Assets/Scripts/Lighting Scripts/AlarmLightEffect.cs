using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLightEffect : MonoBehaviour
{
    [SerializeField] Light alarmLight;
    [SerializeField] float flashInterval = 1;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > flashInterval)
        {
            alarmLight.enabled = !alarmLight.enabled;
            timer -= flashInterval;
        }
    }
}
