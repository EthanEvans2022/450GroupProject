using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public abstract class MovementHandler : MonoBehaviour
{
    //DEGREGATED
    //TODO: DELETE FILE

    /*
    //Outlets
    protected Transform tf;
    protected Rigidbody2D rb;
    protected Collider coll;
    protected SpriteRenderer sprite_renderer;
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
       sprite_renderer = GetComponent<SpriteRenderer>();
    }
    public void Update(){
        InputListener();
    }
    //Helper Methods

    //Updates transform of controller
    virtual protected void Move(Vector2 vector)
    {
        //take a unit vector + multiply by speed?
        Vector2 direction = vector.normalized; 
        rb.velocity = direction * speed;
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
*/

}
