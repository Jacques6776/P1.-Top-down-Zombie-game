using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{

    private InputAction fire;
    public PlayerInputManager playerControls;

    [SerializeField] GameObject bullet;
    
    void Awake() 
    {
        playerControls = new PlayerInputManager();
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
   
    private void Fire(InputAction.CallbackContext context)
    {
       bullet.GetComponent<ParticleSystem>().Play();
    }

    //Ammo controll section
}
