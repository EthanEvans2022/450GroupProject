using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour {
    //outlet
    public TMP_Text textHealth;
    
    public int health;

    public void healthUpdate(int x) {
        health += x;
        updateDisplay();
    }

    void updateDisplay() {
        textHealth.text = health.ToString();
    }
    
    
    // Start is called before the first frame update
    void Start() {
        health = 100;
    }

    // Update is called once per frame
    int interval = 1; 
    float nextTime = 0;
     
    // Update is called once per frame
    void Update () {
        
        if (Time.time >= nextTime) {
            healthUpdate(-1);
            updateDisplay();
 
            nextTime += interval; 
 
        }
     
    }

}
