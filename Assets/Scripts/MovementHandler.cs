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

    //States

    //Methods
    public MovementHandler(float speed){
        this.speed = speed;
    }
    void Start()
    {
       tf = GetComponent<Transform>(); 
       rb = GetComponent<Rigidbody2D>();
    }
    public void Update(){
        InputListener();
    }
    //Helper Methods

    //Updates transform of controller
    protected void Move(Vector2 vector){
        //take a unit vector + multiply by speed?
        tf.position += new Vector3(vector.x, vector.y, 0) * speed;
    }

    //Ethan 
    protected void Rotate(Vector2 vector){
        throw new NotImplementedException();
    }

    protected void SetPosition(Vector3 vector){
        tf.position = vector;
    }

    //Mark
    protected void AddForce(Vector3 vector){
        throw new NotImplementedException();
    }
    protected abstract void InputListener();

}
