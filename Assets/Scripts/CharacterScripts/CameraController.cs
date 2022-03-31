using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //State
    bool isCombined = false;
    //Outlets
    Camera combinedCamera;
    Camera keyboardCamera;
    Camera mouseCamera;
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
        combinedCamera = GameObject.Find("Combined Camera").GetComponent<Camera>();
        keyboardCamera = GameObject.Find("Keyboard Camera").GetComponent<Camera>();
        mouseCamera = GameObject.Find("Mouse Camera").GetComponent<Camera>();

        if(combinedCamera == null || keyboardCamera == null || mouseCamera == null){
            Debug.LogError("MISSING A CAMERA");
        }


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
