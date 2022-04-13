using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseController : MonoBehaviour 
{
    //Outlets
    public static MouseController instance;
    protected Transform tf;
    protected Rigidbody2D rb;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    private Animator[] _animators;

    //Configurations
    public float speed;
    public float mouseBuffer = 0.01f;
    Camera mouseCamera;

    //States
    public bool isPaused;
    
    //POC state, allows for switching between movements in demo
    private enum MovementType{
        Teleport,
        Follow,
        Track
    }
    private MovementType movementType;

    //Methods
    void Awake()
    {
        instance = this;
    }
    void Start(){
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        
       tf = GetComponent<Transform>(); 
       rb = GetComponent<Rigidbody2D>();
       movementType = MovementType.Follow;
       _animators = GetComponentsInChildren<Animator>();
       
       mouseCamera = GameObject.Find("Mouse Camera").GetComponent<Camera>();
    }
    void Update(){
        if (isPaused) {
            return;
        }
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
            //tf.position = GetMouseLocation();
            navMeshAgent.destination = GetMouseLocation();
        }
    }



    //Move in the direction of the mouse is
    private void FollowMouse(){
        Vector3 mousePos = GetMouseLocation();
        Vector3 currPos = mouseCamera.WorldToViewportPoint(tf.position);
        Vector3 diff = mousePos - currPos;
        Vector2 direction = (diff.x * diff.x + diff.y * diff.y) < mouseBuffer*mouseBuffer ? new Vector2(0,0) : new Vector2(diff.x, diff.y);
        //Vector3 diff =currPos - mousePos;     Happy little accident: character repulsed from mouse, can be fun chase AI later 
        rb.velocity = direction.normalized * speed;
        foreach (var animator in _animators)
        {
            //This throws a warning when movementX and movementY don't exist on an animator
        animator.SetFloat("MovementX", rb.velocity.x);
        animator.SetFloat("MovementY", rb.velocity.y);
            
        }
    }

    private Vector3 GetMouseLocation(){
        Vector3 mousePos = mouseCamera.ScreenToViewportPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
