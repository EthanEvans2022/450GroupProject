using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTwoBehavior : MonoBehaviour
{
    
    public void NextLevel()
    {
        SceneManager.LoadScene("LightingTest");
    }
}
