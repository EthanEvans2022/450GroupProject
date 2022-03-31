using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//using Complete;

public class StateController : MonoBehaviour {
    private bool _aiActive;
    public State currentState;

    
    public CombinedController combined;
    public KeyboardController keyboard;
    public MouseController mouse;
    
    //Outlets
    public GameObject keyboardPlayer;
    public GameObject mousePlayer;
    public GameObject combinedPlayer;

    public HealthController keyboardPlayerHC;
    public HealthController mousePlayerHC;
    public HealthController combinedPlayerHC;
    public HealthController selfHC;


    
    
    public Sprite normalSprite;
    public Sprite attackingSprite;
    public Transform eyes;
    public List<Transform> wayPointList;
    
    [HideInInspector] public  SpriteRenderer sprite_renderer;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public int nextWayPoint;

    
    public float attack_range;
    public float sight_range;
    public int attackPower;


    void Awake() {
        // tankShooting = GetComponent<Complete.TankShooting> ();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        sprite_renderer = GetComponent<SpriteRenderer>();
        selfHC = GetComponent<HealthController>();
        combinedPlayer = combined.gameObject;
        keyboardPlayer = keyboard.gameObject;
        mousePlayer = mouse.gameObject;
        keyboardPlayerHC = keyboardPlayer.GetComponent<HealthController>();
        mousePlayerHC = mousePlayer.GetComponent<HealthController>();
        combinedPlayerHC = combinedPlayer.GetComponent<HealthController>();

    }
    
    void Update() {
        if (_aiActive)
            return;
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState) {
        
        if (nextState != currentState) {
            currentState = nextState;
            
        }
    }

    private void OnExitState() {
        
    }
}