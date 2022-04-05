using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        // get the next level menu up when colliding with a player; TODO: figure out how to get this to trigger only when the player is combined
        if (other.gameObject.layer == 8)
        {
            //MenuController.instance.ShowNextMenu();
        }
    }
}
