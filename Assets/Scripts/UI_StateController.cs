using System;
using TMPro;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class UI_StateController : MonoBehaviour
{
    //outlet
    public CombinedController combined;
    public KeyboardController keyboard;
    public MouseController mouse;


    [HideInInspector] public GameObject keyboardPlayer;
    [HideInInspector] public GameObject mousePlayer;
    [HideInInspector] public GameObject combinedPlayer;

    [HideInInspector] public HealthController keyboardPlayerHC;
    [HideInInspector] public HealthController mousePlayerHC;
    [HideInInspector] public HealthController combinedPlayerHC;

    public TMP_Text keyboardHealthText;
    public TMP_Text mouseHealthText;

    [FormerlySerializedAs("NotificationText")]
    public TMP_Text notificationText;

    //fields
    public float interval = 1;
    public float nextTime;
    public bool depletingFlag;




    private void Start()
    { 
        combinedPlayer = combined.gameObject;
        keyboardPlayer = keyboard.gameObject;
        mousePlayer = mouse.gameObject;
        keyboardPlayerHC = keyboardPlayer.GetComponentInParent<HealthController>();
        mousePlayerHC = mousePlayer.GetComponentInParent<HealthController>();
        combinedPlayerHC = combinedPlayer.GetComponentInParent<HealthController>();
        //Debug.Log("UIController Started");
        UpdateHealthDisplay();
    }

    private void Update()
    {
        
        
        var lineRenderer = GetComponent<LineRenderer>();
        if (mousePlayer.activeSelf) {
            
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, mousePlayer.gameObject.transform.position);
            lineRenderer.SetPosition(1, keyboardPlayer.gameObject.transform.position);
        }
        else {
            lineRenderer.positionCount = 0;
        }


        if (CheckDepletingState())
            depletingFlag = true;
        else
            depletingFlag = false;
        UpdateHealthDisplay();
        Depleting();
    }


    public void HealthUpdate(HealthController player, int x)
    {
        player.DealDamage(-x);
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (mousePlayer.activeSelf) {
            keyboardHealthText.text = "Your's Health: " + keyboard.gameObject.GetComponentInParent<HealthController>().currentHealth;
            mouseHealthText.text = "Soul's Health: " + mouse.gameObject.GetComponentInParent<HealthController>().currentHealth;
        }
        else {
            keyboardHealthText.text = "Your's Health: " + combined.gameObject.GetComponentInParent<HealthController>().currentHealth;
            mouseHealthText.text = "";
        }
        
      
    }

    private void UpdateNotificationDisplay(string text)
    {
        notificationText.text = text;
    }

    private void Depleting()
    {
        if (Time.time >= nextTime)
        {
            if (depletingFlag)
            {
                HealthUpdate(keyboardPlayerHC, -1);
                HealthUpdate(mousePlayerHC, -1);
            }

            nextTime += interval;
        }
    }

    private bool CheckDepletingState()
    {
        // Debug.Log(mousePlayer.transform.position);
        // Debug.Log(keyboardPlayer.transform.position);
        var distance = Math.Sqrt(
            Math.Pow(mousePlayer.transform.position.x - keyboardPlayer.transform.position.x, 2)
            + Math.Pow(
                mousePlayer.gameObject.transform.position.y -
                keyboardPlayer.gameObject.transform.position.y,
                2
            )
        );
        //Debug.Log(distance);
        if (distance > 6.5)
        {
            UpdateNotificationDisplay("LOSING SOUL !!!");
            keyboardHealthText.color = new Color32(255, 19, 19, 255);
            mouseHealthText.color = new Color32(255, 19, 19, 255);
            return true;
        }

        UpdateNotificationDisplay("");
        keyboardHealthText.color = new Color32(255, 255, 255, 255);
        mouseHealthText.color = new Color32(255, 255, 255, 255);
        return false;
    }
}

public struct DepletingByTimeJob : IJobParallelFor
{
    public NativeArray<float> A;

    public NativeArray<float> B;
    public NativeArray<float> Result;

    public void Execute(int i)
    {
        Result[i] = A[i] + B[i];
    }
}