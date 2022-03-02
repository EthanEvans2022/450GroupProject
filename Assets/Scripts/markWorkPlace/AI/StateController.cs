using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Complete;

public class StateController : MonoBehaviour {
    private bool aiActive;
    public State currentState;
    public State remainState;
    private GameObject keyboardPlayer;
    private GameObject mousePlayer;
    
    
    //public EnemyStats enemyStats;
    // public Transform eyes;
   //[HideInInspector] public Complete.TankShooting tankShooting;
   //[HideInInspector] public Transform chaseTarget;

    //[HideInInspector] public NavMeshAgent navMeshAgent;
   // [HideInInspector] public List<Transform> wayPointList;
    //[HideInInspector] public int nextWayPoint;
    [HideInInspector] public float stateTimeElapsed;

    


    void Awake () 
    {
        // tankShooting = GetComponent<Complete.TankShooting> ();
        // navMeshAgent = GetComponent<NavMeshAgent> ();
        
    }

    public void SetupAI(bool aiActivationFromLevelMaster, GameObject keyboardPlayer, GameObject mousePlayer)
    {
        // wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromLevelMaster;
        this.keyboardPlayer = keyboardPlayer;
        this.mousePlayer = mousePlayer;

        // if (aiActive) 
        // {
        //     navMeshAgent.enabled = true;
        // } else 
        // {
        //     navMeshAgent.enabled = false;
        // }
    }



    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState (this);
    }

    // void OnDrawGizmos()
    // {
    //     if (currentState != null && eyes != null) 
    //     {
    //         Gizmos.color = currentState.sceneGizmoColor;
    //         Gizmos.DrawWireSphere (eyes.position, enemyStats.lookSphereCastRadius);
    //     }
    // }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState) 
        {
            currentState = nextState;
            OnExitState ();
        }
    }

    // public bool CheckIfCountDownElapsed(float duration)
    // {
    //     stateTimeElapsed += Time.deltaTime;
    //     return (stateTimeElapsed >= duration);
    // }

    private void OnExitState()
    {
        //stateTimeElapsed = 0;
    }
}