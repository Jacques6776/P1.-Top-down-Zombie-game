using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoIncreaseAmount = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AmmoController>().IncreaseCurrentAmmo(ammoType,ammoIncreaseAmount);
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
