using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{

    private InputAction fire;
    public PlayerInputManager playerControls;

    [SerializeField] GameObject bullet;
    
    [SerializeField] AmmoType ammoType;
    [SerializeField] AmmoController ammoSlot;

    [SerializeField] TextMeshProUGUI ammoText;
    
    void Awake() 
    {
        playerControls = new PlayerInputManager();
    }

    private void Update() 
    {
        DisplayAmmo();
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    //Firing controll section
    void OnEnable() 
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    void OnDisable() 
    {
        fire.Disable();
    }
   
    public void Fire(InputAction.CallbackContext context)
    {
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            bullet.GetComponent<ParticleSystem>().Play();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
    }
}
