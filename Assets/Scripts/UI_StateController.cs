using System;
using TMPro;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class UI_StateController : MonoBehaviour
{
    //outlet
    private GameObject _keyboardPlayer;
     private GameObject _mousePlayer;

    private HealthController _mousePlayerHc;

    public TMP_Text mouseHealthText;


    //fields
    public float interval = 1;
    public float nextTime;
    public bool depletingFlag;




    private void Start()
    { 
        _keyboardPlayer = CharacterController.instance.keyboardInstance;
        _mousePlayer = CharacterController.instance.mouseInstance;
        // keyboardPlayerHC = keyboardPlayer.GetComponentInParent<HealthController>();
        _mousePlayerHc = CharacterController.instance.gameObject.GetComponent<HealthController>();

        // combinedPlayerHC = combinedPlayer.GetComponentInParent<HealthController>();
        //Debug.Log("UIController Started");
        UpdateHealthDisplay();
    }

    private void Update()
    {
        
        
        var lineRenderer = GetComponent<LineRenderer>();
        if (_mousePlayer.activeSelf) {
            
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, _mousePlayer.gameObject.transform.position);
            lineRenderer.SetPosition(1, _keyboardPlayer.gameObject.transform.position);
        }
        else {
            lineRenderer.positionCount = 0;
        }


        depletingFlag = CheckDepletingState();
        UpdateHealthDisplay();
        Depleting();
    }


    private void HealthUpdate(HealthController player, int x)
    {
        player.DealDamage(-x);
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {

        mouseHealthText.text = "Health: " + _mousePlayerHc.currentHealth;

    }

    private void Depleting()
    {
        if (Time.time >= nextTime)
        {
            if (depletingFlag)
            {
                HealthUpdate(_mousePlayerHc, -1);
            }

            nextTime += interval;
        }
    }

    private bool CheckDepletingState()
    {
        // Debug.Log(mousePlayer.transform.position);
        // Debug.Log(keyboardPlayer.transform.position);
        print(_mousePlayer.transform.position);
        var distance = Math.Sqrt(
            Math.Pow(_mousePlayer.transform.position.x - _keyboardPlayer.transform.position.x, 2)
            + Math.Pow(
                _mousePlayer.gameObject.transform.position.y -
                _keyboardPlayer.gameObject.transform.position.y,
                2
            )
        );
        //Debug.Log(distance);
        if (distance > 6.5)
        {
            mouseHealthText.color = new Color32(255, 19, 19, 255);
            return true;
        }

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