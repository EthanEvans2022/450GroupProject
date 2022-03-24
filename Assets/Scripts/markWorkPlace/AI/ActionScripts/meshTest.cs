using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class meshTest : MonoBehaviour {
    NavMeshAgent navMeshAgent;

    public List<Transform> wayPointList;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent> ();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.SetDestination(goal.position);

    }
}
