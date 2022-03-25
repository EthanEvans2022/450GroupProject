using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//using Complete;

public class StateController : MonoBehaviour {
    private bool _aiActive;
    public State currentState;

    public GameObject keyboardPlayer;
    public GameObject mousePlayer;
    // public GameController enemyStats;
    public Sprite normalSprite;
    public Sprite attackingSprite;
    public Transform eyes;
    public List<Transform> wayPointList;
    
    [HideInInspector] public  SpriteRenderer sprite_renderer;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public int nextWayPoint;

    public float health;
    public float attack_range;
    public float sight_range;


    void Awake() {
        // tankShooting = GetComponent<Complete.TankShooting> ();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        sprite_renderer = GetComponent<SpriteRenderer>();
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