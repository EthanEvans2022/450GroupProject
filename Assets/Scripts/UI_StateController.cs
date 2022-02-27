using System;
using TMPro;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Serialization;

public class UI_StateController : MonoBehaviour
{
    //outlet
    public HealthController keyboardPlayer;
    public HealthController mousePlayer;

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
        Debug.Log("UIController Started");
        UpdateHealthDisplay();
    }

    private void Update()
    {
        var lineRenderer = GetComponent<LineRenderer>();
        if (mousePlayer.gameObject.activeSelf)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, mousePlayer.gameObject.transform.localPosition);
            lineRenderer.SetPosition(1, keyboardPlayer.gameObject.transform.localPosition);
        }
        else
        {
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
        keyboardHealthText.text = "Player's Health: " + keyboardPlayer.currentHealth;
        mouseHealthText.text = "Soul's Health: " + mousePlayer.currentHealth;
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
                HealthUpdate(keyboardPlayer, -1);
                HealthUpdate(mousePlayer, -1);
            }

            nextTime += interval;
        }
    }

    private bool CheckDepletingState()
    {
        // Debug.Log(mousePlayer.transform.position);
        // Debug.Log(keyboardPlayer.transform.position);
        var distance = Math.Sqrt(Math.Pow(mousePlayer.transform.position.x - keyboardPlayer.transform.position.x, 2)
                                 + Math.Pow(
                                     mousePlayer.gameObject.transform.position.y -
                                     keyboardPlayer.gameObject.transform.position.y,
                                     2));
        //Debug.Log(distance);
        if (distance > 5)
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