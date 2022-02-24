using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    //Outputs
    protected Transform tf;
    protected Rigidbody2D rb;
    protected SpriteRenderer sprite_renderer;
    public GameObject mousePlayer;
    public Sprite combinedSprite;
    public Sprite seperateSprite;
    //Configurations 
    public float speed;
    public float speedPenalty = 1;
    /*PROTOTYPES: Not being used
    public float rotationSpeed;
    public float dashMultiplier;
    */
    //States
    private bool isCombined;
    //Methods
    void Start(){
       tf = GetComponent<Transform>(); 
       rb = GetComponent<Rigidbody2D>();
       sprite_renderer = GetComponent<SpriteRenderer>();
       isCombined = true;
       CombineCharacters();
    }

    void Update(){
        InputListener();
    }

    private void InputListener(){
        //Movement Controls
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            direction += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.D))
            direction += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.W))
            direction += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            direction += new Vector2(0, -1);
        rb.velocity = direction.normalized * speed;

        //Combine Control
        if (Input.GetKeyDown(KeyCode.C)){
            isCombined = !isCombined;
            CombineCharacters();
        }
    }
    protected void CombineCharacters(){
        if(isCombined){
            //Deactivate mousePlayer
            mousePlayer.SetActive(false);
            //Change current keyboard player sprite
            sprite_renderer.sprite = combinedSprite;
            //Update speed
            speed *= speedPenalty;
        }
        else{
            //Activate mousePlayer
            mousePlayer.SetActive(true);
            mousePlayer.transform.position = tf.position;
            //Change keyboard player sprite
            sprite_renderer.sprite = seperateSprite;
            //Update speed
            speed /= speedPenalty;
        }
    }

    //PROTOTYPES: Not currently being used
    //Drifitng controls like Q2
    /*
    protected void DriftingControls(){
        if (Input.GetKey(KeyCode.A)) {
            rb.AddRelativeForce(Vector2.up * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            rb.AddRelativeForce(Vector2.up * -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W)) {
            rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
        }
    }
    
    //Similar to standard controls, but adds dash/sprinting aspect
    protected void DashControls(){
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector2.up * speed * dashMultiplier * Time.deltaTime);
        }
    }
    */
}
