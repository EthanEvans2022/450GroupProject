using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public string _targetdoor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.name == _targetdoor)
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
