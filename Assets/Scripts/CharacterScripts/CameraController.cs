using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //State
    bool isCombined = false;
    //Outlets
    public Camera combinedCamera;
    public Camera keyboardCamera;
    public Camera mouseCamera;
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        if(isCombined != characterController.isCombined){
            isCombined = !isCombined;
            if(isCombined)
                EnableCombinedCamera();
            else
                EnableSplitCameras();
        } 
    }
    void EnableCombinedCamera(){
        combinedCamera.enabled = true;
        keyboardCamera.enabled = false;
        mouseCamera.enabled = false;
    }
    void EnableSplitCameras(){
        combinedCamera.enabled = false;
        keyboardCamera.enabled = true;
        mouseCamera.enabled = true;
    }
}
