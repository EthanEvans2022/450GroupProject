using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MovementHandler
{
    //Outputs
    //Configurations 
    float speed = 0.02f;
    //States

    //Methods
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    void Update()
    {
       InputListener(); 
    }

    override protected void InputListener(){
        //Up
        if(Input.GetKey(KeyCode.UpArrow)){
            Move(new Vector2(0, speed));
        }       
        //Down
        if(Input.GetKey(KeyCode.DownArrow)){
            Move(new Vector2(0, -speed));
        }       
        //Left
        if(Input.GetKey(KeyCode.LeftArrow)){
            Move(new Vector2(-speed, 0));
        }       
        //Right
        if(Input.GetKey(KeyCode.RightArrow)){
            Move(new Vector2(speed, 0));
        }     
    }
}
