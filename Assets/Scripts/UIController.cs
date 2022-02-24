using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour {
    //outlet
    public TMP_Text keyboardHealthText;
    public TMP_Text mouseHealthText;
    
    
    //fields
    public int keyboardHealth;
    public int mouseHealth;
   

    public void healthUpdate(int x) {
        switch (player) {
            
        }
        health += x;
        updateDisplay();
    }

    void updateDisplay() {
        keyboardHealthText.text = keyboardHealth.ToString();
        mouseHealthText.text = mouseHealth.ToString();
    }
    
    void depleting(int interval, float nextTime) {
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
