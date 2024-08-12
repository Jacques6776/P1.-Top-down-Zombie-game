using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] AmmoController ammoSlot;
    [SerializeField] TextMeshProUGUI ammoText;

    private void Update() 
    {
        DisplayAmmo();
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

}
