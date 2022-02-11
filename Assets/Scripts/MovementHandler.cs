using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class MovementHandler : MonoBehaviour
{
    //Outlets
    protected Transform tf;
    protected Rigidbody2D rb;
    protected Collider collider;
    //Configurations
    public float speed;
    
    public float rotationSpeed; //Mark added

    //States

    //Methods
    public MovementHandler(float speed, float rotationSpeed) {
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
    }
    void Start(){
       tf = GetComponent<Transform>(); 
       rb = GetComponent<Rigidbody2D>();
    }
    public void Update(){
        InputListener();
    }
    //Helper Methods

    //Updates transform of controller
    protected void Move(Vector2 vector)
    {
        //take a unit vector + multiply by speed?
        tf.position += new Vector3(vector.x, vector.y, 0) * speed / 3000; //add a constant to balance different controls
    }

    //Ethan 
    protected void Rotate(Vector2 vector){
        throw new NotImplementedException();
    }

    protected void SetPosition(Vector3 vector){
        tf.position = vector;
    }

    //Mark
    protected void AddForce(float speed){
        rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
    }
    protected void AddTorque(float rotationSpeed){
        rb.AddTorque(rotationSpeed * Time.deltaTime);
    }
    protected abstract void InputListener();

}
