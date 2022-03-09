using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedController : MovementHandler 
{
    //Outlets
    protected SpriteRenderer sprite_renderer;
    protected Rigidbody2D rb;
    protected CapsuleCollider2D capsuleCollider;
    public GameObject keyboardPrefab;
    public GameObject mousePrefab;
    public GameObject projectilePrefab;
    //Configurations
    public float speed = 10;
    //States
    public bool isCombined = true;
    //Methods
    protected void Start(){
        rb = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    protected void Update(){
        if(isCombined){
            CombinedControls();
        }
        if(Input.GetKeyDown(KeyCode.C)){
            ToggleCharacterCombined();
        }
    }
    //Controls for when players are combined
    protected void CombinedControls(){
        //WASD Movement controlls reused
        Vector2 keyboardDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            keyboardDirection += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.D))
            keyboardDirection += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.W))
            keyboardDirection += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            keyboardDirection += new Vector2(0, -1);
        rb.velocity = keyboardDirection.normalized * speed;

        //Rotate player in direction
        Vector3 mousePosition = GetMouseLocation();
        Vector3 currPos = transform.position;
        Vector3 mouseDirection = mousePosition - currPos;
        //TODO: Change sprite on rotation to match direction of mouse pointing
        transform.up = mouseDirection;

        //Fire Projectile
        if(Input.GetMouseButtonDown(0)){
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
        }


    }

    //Toggle Combined or Split
    public void ToggleCharacterCombined(){
        if(isCombined)
            SplitCharacters();
        else
            CombineCharacters();
        isCombined = !isCombined;
    }
    //Handles the splitting of characters
    protected void SplitCharacters(){
        //Deactivate all componenets + child light
        rb.Sleep();
        capsuleCollider.enabled = false;
        sprite_renderer.enabled = false;
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach(Transform child in children){
            if(child.gameObject.name == "Light 2D"){
                Debug.Log("deactivating light");
                child.gameObject.SetActive(false);
            }
        }
        //light2d.SetActive(false);
        //Spawn new keyboardPlayer + mousePlayer at current location
        GameObject keyboardPlayer = Instantiate(keyboardPrefab, transform.position, Quaternion.identity, transform);
        keyboardPlayer.transform.position = transform.position;

        GameObject mousePlayer = Instantiate(mousePrefab, transform.position + new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity, transform);
        mousePlayer.transform.position = transform.position;

    }

    protected void CombineCharacters(){
        //Activate all components
        rb.WakeUp();
        capsuleCollider.enabled = true;
        sprite_renderer.enabled = true;
        //BUG: Can't get light working again when recombining
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach(Transform child in children){
            Debug.Log(child.gameObject.name);
            if(child.gameObject.name == "Light 2D"){
                Debug.Log("activating light");
                child.gameObject.SetActive(true);
                Debug.Log(child.gameObject.activeSelf);
            }
        }

        GameObject keyboardPlayer = GetComponentInChildren<KeyboardController>().gameObject;
        GameObject mousePlayer = GetComponentInChildren<MouseController>().gameObject;

        transform.position = keyboardPlayer.transform.position;

        Destroy(keyboardPlayer);
        Destroy(mousePlayer);

    }
    private Vector3 GetMouseLocation(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

}
