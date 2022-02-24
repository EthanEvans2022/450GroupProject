using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;
using Unity.Mathematics;
using static Unity.Mathematics.math;

public class UI_StateController : MonoBehaviour {
    //outlet
    public GameObject keyboardPlayer;
    public GameObject mousePlayer;
    
    public TMP_Text keyboardHealthText;
    public TMP_Text mouseHealthText;
    public TMP_Text NotificationText;
    
    //fields
    public int keyboardHealth;
    public int mouseHealth;
    public int interval = 1;
    public float nextTime = 0;
    public bool depletingFlag = false;
    public enum Player {
        keyboardPlayer,
        mousePlayer
    }
    

    

    public void healthUpdate(Player player, int x) {
        switch (player) {
            case Player.keyboardPlayer:
                keyboardHealth += x;
                break;
            case Player.mousePlayer:
                mouseHealth += x;
                break;
        }
        updateHealthDisplay();
    }

    void updateHealthDisplay() {
        keyboardHealthText.text = "Aiden's Health: " + keyboardHealth.ToString();
        mouseHealthText.text = "Soul's Health: " + mouseHealth.ToString();
    }

    void updateNotificationDisplay(string text) {
        NotificationText.text = text;
    }
    
    void depleting() {
        if (Time.time >= nextTime) {
            if (depletingFlag) {
                healthUpdate(Player.keyboardPlayer, -1);
                healthUpdate(Player.mousePlayer, -1);
            }
            nextTime += interval;
        }
    }

    bool checkDepletingState() {
        // Debug.Log(mousePlayer.transform.position);
        // Debug.Log(keyboardPlayer.transform.position);
        double distance = Math.Sqrt(Math.Pow(mousePlayer.transform.position.x - keyboardPlayer.transform.position.x, 2)
                                   + Math.Pow(mousePlayer.transform.position.y - keyboardPlayer.transform.position.y,
                                       2));
        //Debug.Log(distance);
        if (distance > 5) {
            updateNotificationDisplay("LOSING SOUL !!!");
            keyboardHealthText.color = new Color32(255, 19, 19, 255);
            mouseHealthText.color = new Color32(255, 19, 19, 255);
            return true;
        }
        else {
            updateNotificationDisplay("");
            keyboardHealthText.color = new Color32(255, 255, 255, 255);
            mouseHealthText.color = new Color32(255, 255, 255, 255);
            return false;
        }
        
    }
    
    
    void Start() {
        Debug.Log("UIController Started");
        updateHealthDisplay();
        
        
    }
    
    void Update () {
        LineRenderer lineRenderer = GetComponent<LineRenderer> ();
        if (mousePlayer.activeSelf) {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition (0, mousePlayer.transform.localPosition);
            lineRenderer.SetPosition (1, keyboardPlayer.transform.localPosition);
        }
        else {
            lineRenderer.positionCount = 0;
        }
       
        
        if (checkDepletingState()) {
            depletingFlag = true;
        }
        else {
            depletingFlag = false;
        }
        Debug.Log(depletingFlag);
        Debug.Log(keyboardHealth);
        updateHealthDisplay();
        depleting();
    }
}

public struct DepletingByTimeJob : IJobParallelFor
{

    public NativeArray<float> a;

    public NativeArray<float> b;
    public NativeArray<float> result;

    public void Execute(int i)
    {
        result[i] = a[i] + b[i];
    }
}
