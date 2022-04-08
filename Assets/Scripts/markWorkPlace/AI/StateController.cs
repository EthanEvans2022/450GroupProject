using System;
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


    [HideInInspector] public GameObject keyboardPlayer;
    [HideInInspector] public GameObject mousePlayer;
    [HideInInspector] public GameObject combinedPlayer;

    public HealthController keyboardPlayerHC;
    public HealthController mousePlayerHC;
    public HealthController combinedPlayerHC;
    public HealthController selfHC;


    public Sprite normalSprite;
    public Sprite attackingSprite;
    public Transform eyes;
    public List<Transform> wayPointList;

    [HideInInspector] public SpriteRenderer sprite_renderer;
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

    public double getDistance(Transform a, Transform b) {
        return Math.Sqrt(Math.Pow(a.position.x - b.position.x, 2) + Math.Pow(a.position.y - b.position.y, 2));
    }

    public GameObject getTarget() {
        if (keyboardPlayer.activeSelf) {
            double KBdistance = getDistance(eyes, keyboardPlayer.transform);
            double MSdistance = getDistance(eyes, mousePlayer.transform);
            if (KBdistance > MSdistance) {
                return mousePlayer;
            }
            return keyboardPlayer;
        }
        else {
            double CBdistance = getDistance(eyes, combined.transform);
            return combinedPlayer;
        }
    }

    private void OnExitState() { }
}