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
    public GameObject projectilePrefab; 
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
       //CombineCharacters();
    }

    void Update(){
        StandardControls(); 
    }

    private void InputListener(){
        //Movement Controls
        //On by default, but could change for when combined 
        StandardControls();
        //Combine Control
        if (Input.GetKeyDown(KeyCode.C)){
        }

		if (Input.GetKeyDown(KeyCode.Return)){
			DialogueController.dialogueControllerInstance.NextText();
		}

		if (Input.GetKeyDown(KeyCode.Escape)){
			MenuController.instance.ToggleMainMenu();
		}
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
        rb.velocity = direction.normalized * speed;
    }
    private void CombinedControls(){
        Vector3 mousePosition = GetMouseLocation();
        Vector3 currPos = tf.position;
        Vector3 direction = mousePosition - currPos;
        //Vector2 direction = diff.magnitude < mouseBuffer ? new Vector2(0,0) : new Vector2(diff.x, diff.y);
        tf.up = direction;

        if(Input.GetMouseButtonDown(0)){
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = tf.position;
            projectile.transform.rotation = tf.rotation;
        }
    }
    protected void CombineCharacters(){
        if(isCombined){
            //Deactivate mousePlayer
            //mousePlayer.SetActive(false);
            //Change current keyboard player sprite
            //sprite_renderer.sprite = combinedSprite;
            //Update speed
            //speed *= speedPenalty;
        }
        else{
            //Activate mousePlayer
            //mousePlayer.SetActive(true);
            //mousePlayer.transform.position = tf.position;
            //Change keyboard player sprite

            //sprite_renderer.sprite = seperateSprite;
            //TEMP: reset up direction
            //tf.up = new Vector3(0,1,0);
            //Update speed
            //speed /= speedPenalty;
        }
    }
    private Vector3 GetMouseLocation(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
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
