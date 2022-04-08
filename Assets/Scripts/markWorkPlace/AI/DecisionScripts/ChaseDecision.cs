using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Chase")]
public class ChaseDecision : Decision 
{
    public override bool Decide (StateController controller)
    {
        bool enemyInSight = Scan (controller);
        return enemyInSight;
    }

    private bool Scan(StateController controller)
    {
        //controller.navMeshAgent.Stop ();
        //controller.transform.Rotate (0,  5 * Time.deltaTime, 0);
        double distance = controller.getDistance(controller.getTarget().transform,controller.eyes);
        if (distance < controller.sight_range && distance > controller.attack_range) {
            return true;
           // Debug.Log("chase: true"+distance);
        }
        // Debug.Log("chase: false"+distance);
        

        return false;
       
    }
}
