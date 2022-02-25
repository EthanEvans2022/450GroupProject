using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Outlets 
    Rigidbody2D rb;
    Transform tf;
    void Start()
    {
       tf = GetComponent<Transform>();
       rb = GetComponent<Rigidbody2D>();
       rb.velocity = tf.up * 10f; 
    }

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}
