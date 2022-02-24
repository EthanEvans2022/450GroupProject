using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour 
{
    //Outputs
    protected Transform tf;
    protected Rigidbody2D rb;

    //Configurations
    public float speed;
    public float mouseBuffer = 0.25f;

    //States
    //POC state, allows for switching between movements in demo
    private enum MovementType{
        Teleport,
        Follow,
        Track
    }
    private MovementType movementType;

    //Methods
    void Start(){
       tf = GetComponent<Transform>(); 
       rb = GetComponent<Rigidbody2D>();
       movementType = MovementType.Follow;
    }
    void Update(){
        InputListener();
    }
    private void InputListener()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            movementType = MovementType.Follow;
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            movementType = MovementType.Teleport;
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
        tf.position = GetMouseLocation();
    }

    //Move to where the player clicks
    private void Teleport(){
        if(Input.GetMouseButtonDown(0)){
            tf.position = GetMouseLocation();
        }
    }

    //Move in the direction of the mouse is
    private void FollowMouse(){
        Vector3 mousePos = GetMouseLocation();
        Vector3 currPos = tf.position;
        Vector3 diff = mousePos - currPos;
        Vector2 direction = diff.magnitude < mouseBuffer ? new Vector2(0,0) : new Vector2(diff.x, diff.y);
        //Vector3 diff =currPos - mousePos;     Happy little accident: character repulsed from mouse, can be fun chase AI later 
        rb.velocity = direction.normalized * speed;
    }

    private Vector3 GetMouseLocation(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
