using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMasterController : MonoBehaviour
{
    public GameObject keyboardPlayer;
    public GameObject mousePlayer;
    public StateController AI_1;
    //public StateController AI_2;
    //...
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerAI_1()) {
            AI_1.SetupAI(true, keyboardPlayer, mousePlayer);
        }
        //...
    }

    bool triggerAI_1() {
        //Need to add Conditions
        if (true) {
            return true;
        }
        else {
            return false;
        }
    }
    
    // bool triggerAI_2() {
    //     //Need to add Conditions
    //     if (true) {
    //         return true;
    //     }
    //     else {
    //         return false;
    //     }
    // }
    
    //...
}
