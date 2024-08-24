using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLighteEffect : MonoBehaviour
{
    //script found on gamedevbeginner https://gamedevbeginner.com/how-to-make-a-light-flicker-in-unity/
    [SerializeField] Light myLight;
    [SerializeField] float maxInterval = 1;
    [SerializeField] float maxFlicker = 0.2f;

    float defaultIntensity;
    bool isOn;
    float timer;
    float delay;

    private void Start()
    {
        defaultIntensity = myLight.intensity;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            ToggleLight();
        }
        }

    void ToggleLight()
    {
        isOn = !isOn;

        if (isOn)
        {
            myLight.intensity = defaultIntensity;
            delay = Random.Range(0, maxInterval);
        }
        else
        {
            myLight.intensity = Random.Range(0.6f, defaultIntensity);
            delay = Random.Range(0, maxFlicker);
        }

        timer = 0;
    }
}
