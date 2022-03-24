using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    //Outputs
    protected Transform Tf;
    protected Rigidbody2D Rb;

    public GameObject projectilePrefab; 
    //Configurations 
    public float speed;
    public float speedPenalty = 1;
    
    //States
	
    //Methods
    void Start(){
       Tf = GetComponent<Transform>(); 
       Rb = GetComponent<Rigidbody2D>();
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
