using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Outlets 
    Rigidbody2D rb;
    Transform tf;
    
    //Config
    public int damage = 0;
    public int lifetime = 3;
    void Start()
    {
       tf = GetComponent<Transform>();
       rb = GetComponent<Rigidbody2D>();
       rb.velocity = tf.up * 10f;
       StartCoroutine(nameof(TimedSelfDestruct));
    }

    private IEnumerator TimedSelfDestruct()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var h =collision.gameObject.GetComponent<HealthController>();
        var h2 = collision.gameObject.GetComponentInParent<HealthController>();
        var health = h ? h : h2;
        if (health)
        {
            health.DealDamage(damage, HealthController.DamageType.Fire);
        }
        Destroy(gameObject);
    }
}
