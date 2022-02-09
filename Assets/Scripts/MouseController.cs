using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MovementHandler
{
    //Outputs
    Camera cam;
    //Configurations

    //States

    //Methods
    void Start()
    {
       tf = GetComponent<Transform>(); 
       cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        InputListener();        
    }

    protected override void InputListener()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        SetPosition(mousePos);
    }
}
