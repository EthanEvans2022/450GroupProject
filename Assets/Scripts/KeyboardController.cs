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
    public KeyboardController(float _speed, float _rotaionSpeed): base(_speed, _rotaionSpeed){

    }


    override protected void InputListener() {
        controlStack();
    }

    protected void controlStack() {
        DriftingControls();
        StandardControls();
        DashControls();
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

    //Mark 
    //Drifitng controls like Q2
    protected void DriftingControls(){
        if (Input.GetKey(KeyCode.A)) {
            AddTorque(rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D)) {
            AddTorque(-rotationSpeed);
        }

        if (Input.GetKey(KeyCode.W)) {
            AddForce(speed);
        }
    }
    
    //Similar to standard controls, but adds dash/sprinting aspect
    protected void DashControls(){
        if (Input.GetKey(KeyCode.Space)) {
            AddForce(speed * 8);
        }
    }
}
