using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    //Outlets
    protected Transform Tf;
    protected Rigidbody2D Rb;
    private Animator _animator;
    public GameObject projectilePrefab; 
    //Configurations 
    public float speed;
    private static readonly int MovementX = Animator.StringToHash("MovementX");
    private static readonly int MovementY = Animator.StringToHash("MovementY");
    
    //States
	
    //Methods
    void Start(){
       Tf = GetComponent<Transform>(); 
       Rb = GetComponent<Rigidbody2D>();
       _animator = GetComponent<Animator>();
       //CombineCharacters();
    }

    void Update()
    {
        StandardControls();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {

        //Rotate player in direction
        var animationDirection = Rb.velocity;
        _animator.SetFloat(MovementX, animationDirection.x);
        _animator.SetFloat(MovementY, animationDirection.y);
        _animator.speed = Rb.velocity.magnitude; //Moving faster should make the animation move faster
    }

    public void StandardControls(){
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            direction += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.D))
            direction += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.W))
            direction += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            direction += new Vector2(0, -1);
        Rb.velocity = direction.normalized * speed;
    }
    private void CombinedControls(){
        Vector3 mousePosition = GetMouseLocation();
        Vector3 currPos = Tf.position;
        Vector3 direction = mousePosition - currPos;
        //Vector2 direction = diff.magnitude < mouseBuffer ? new Vector2(0,0) : new Vector2(diff.x, diff.y);
        Tf.up = direction;

        if(Input.GetMouseButtonDown(0)){
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = Tf.position;
            projectile.transform.rotation = Tf.rotation;
        }
    }
    
    private Vector3 GetMouseLocation(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

}
