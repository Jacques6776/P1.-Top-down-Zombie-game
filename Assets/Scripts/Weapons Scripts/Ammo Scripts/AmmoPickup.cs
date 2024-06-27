using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoIncreaseAmount = 5;
    [SerializeField] AmmoType ammoType;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AmmoController>().IncreaseCurrentAmmo(ammoType,ammoIncreaseAmount);

            Destroy(gameObject);
        }
    }
}
