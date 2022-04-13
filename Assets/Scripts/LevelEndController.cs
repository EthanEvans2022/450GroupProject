using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public int nextSceneIndex;
    void OnTriggerEnter2D(Collider2D other)
    {
        // get the next level menu up when colliding with a player;
        if (other.gameObject.GetComponent<CombinedController>())
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
