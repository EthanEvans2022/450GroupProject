using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Patrol")]
public class PatrolDecision : Decision 
{
    public override bool Decide (StateController controller)
    {
        bool enemyOutSight = Scan (controller);
        return enemyOutSight;
    }

    private bool Scan(StateController controller)
    {
        //controller.navMeshAgent.Stop ();
        //controller.transform.Rotate (0,  5 * Time.deltaTime, 0);
        double distance = controller.getDistance(controller.getTarget().transform,controller.eyes);
        
        if (distance > (1.5 * controller.sight_range)){
            
            return true;
        }
        Debug.Log("falseeee"+distance);
        return false;
       
    }
}
