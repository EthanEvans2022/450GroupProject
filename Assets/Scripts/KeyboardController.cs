using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KeyboardController : MovementHandler
{
    //Outputs
    //Configurations 
    //States

    //Methods
    public KeyboardController(float _speed): base(_speed){

    }


    override protected void InputListener(){
        StandardControls();
    }

    protected void StandardControls(){
         //Up
        if(Input.GetKey(KeyCode.UpArrow)){
            Move(new Vector2(0, 1));
        }       
        //Down
        if(Input.GetKey(KeyCode.DownArrow)){
            Move(new Vector2(0, -1));
        }       
        //Left
        if(Input.GetKey(KeyCode.LeftArrow)){
            Move(new Vector2(-1, 0));
        }       
        //Right
        if(Input.GetKey(KeyCode.RightArrow)){
            Move(new Vector2(1, 0));
        }    
    }

    //Mark v
    //Drifitng controls like Q2
    protected void DriftingControls(){
        throw new NotImplementedException();
    }
    
    //Similar to standard controls, but adds dash/sprinting aspect
    protected void DashControls(){
        throw new NotImplementedException();
    }
}
