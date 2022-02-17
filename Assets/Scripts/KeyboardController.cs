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
    
	// override protected void Move(Vector2 vector)
 //    {
 //        rb.velocity = vector;
 //        //take a unit vector + multiply by speed?
 //        //tf.position += new Vector3(vector.x, vector.y, 0) * speed / 3000; //add a constant to balance different controls
 //    }
    protected void StandardControls(){
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += new Vector2(0, -1);
        }
        Move(direction);
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
