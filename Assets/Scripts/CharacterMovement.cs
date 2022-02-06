using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float _speed = 10;
    // Start is called before the first frame update
    private void Start()
    {
    }

    private Vector3 GetNormalizedMovementDirection(){
        Vector3 transformVector = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            transformVector += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transformVector += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transformVector += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transformVector += new Vector3(0, -1, 0);
        }
        return transformVector.normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = _speed * GetNormalizedMovementDirection() ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("in collision enter function");
        if (collision.gameObject.name == "Collision")
        {
            print("in if statement of  collision function");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}