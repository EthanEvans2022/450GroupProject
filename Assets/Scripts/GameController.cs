using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour {
    //outlet
    public TMP_Text textHealth;
    
    
    //fields
    public int health;
    int interval = 1; 
    private float nextTime = 0;

    public void healthUpdate(int x) {
        health += x;
        updateDisplay();
    }

    void updateDisplay() {
        textHealth.text = health.ToString();
    }
    
    void depleting() {
        if (Time.time >= nextTime) {
            healthUpdate(-1);
            updateDisplay();
            nextTime += interval;
        }
    }

    void checkDepletingState() {
        if (true) {
            depleting();
        }
    }
    
    
    void Start() {
        health = 100;
    }
    
    void Update () {
        checkDepletingState();


    }

}
