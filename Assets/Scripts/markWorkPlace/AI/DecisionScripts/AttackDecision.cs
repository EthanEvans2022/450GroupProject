using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Attack")]
public class AttackDecision : Decision 
{
    public override bool Decide (StateController controller)
    {
        bool enemyInAttack_range = Scan (controller);
        return enemyInAttack_range;
    }

    private bool Scan(StateController controller)
    {
        //controller.navMeshAgent.Stop ();
        //controller.transform.Rotate (0,  5 * Time.deltaTime, 0);
        double distance = controller.getDistance(controller.getTarget().transform,controller.eyes);
        if (distance < controller.attack_range) {
            return true;
        }
        
        return false;
      
    }
}
