using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{    
    Camera mainCamera;
    //can set this to an object for the transform

    void Start() 
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()//found in unity thread https://discussions.unity.com/t/player-rotating-towards-mouse-3d/231407
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);           
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
