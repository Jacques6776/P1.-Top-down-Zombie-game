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
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire(InputAction.CallbackContext context)
    {
       bullet.GetComponent<ParticleSystem>().Play();
    }
}
