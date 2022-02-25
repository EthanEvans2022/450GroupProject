using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        print("in OnCollisionEnter2D");
        // get the next level menu up when colliding with a player; TODO: figure out how to get this to trigger only when the player is combined
        if (other.gameObject.layer == 8)
        {
            print("in the if statement of OnCollisionEnter2D");
            MenuController.instance.ShowNextMenu();
        }
    }
}
