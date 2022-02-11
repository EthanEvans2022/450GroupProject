using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MovementHandler
{
    //Outputs

    //Configurations

    //States
    //POC state, allows for switching between movements in demo
    private enum MovementType{
        Teleport,
        Follow,
        Track
    }
    private MovementType movementType;

    //Methods
    public MouseController(float _speed, float _rotaionSpeed): base(_speed, _rotaionSpeed){

    }
    protected override void InputListener()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            movementType = MovementType.Teleport;
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            movementType = MovementType.Follow;
        }
        if(Input.GetKey(KeyCode.Alpha3)){
            movementType = MovementType.Track;
        }
        switch(movementType){
            case MovementType.Teleport:
                Teleport();
                break;
            case MovementType.Follow:
                FollowMouse();
                break;
            case MovementType.Track:
                TrackMouse();
                break;
        }
    }

    //Follow mouse exactly
    private void TrackMouse(){
        SetPosition(GetMouseLocation());
    }

    //Move to where the player clicks
    private void Teleport(){
        if(Input.GetMouseButtonDown(0)){
            SetPosition(GetMouseLocation());
        }
    }

    //Move in the direction of the mouse is
    //BUG: sprite shakes when on top of mouse
    private void FollowMouse(){
        Vector3 mousePos = GetMouseLocation();
        Vector3 currPos = tf.position;
        Vector3 diff = mousePos - currPos;
        //Vector3 diff =currPos - mousePos;     Happy little accident: character repulsed from mouse, can be fun chase AI later 
        Vector3 normal = Vector3.Normalize(diff);
        Move(new Vector2(normal.x, normal.y));
    }

    private Vector3 GetMouseLocation(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
