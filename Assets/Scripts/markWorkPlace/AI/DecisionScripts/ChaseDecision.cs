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
        double KBdistance = Math.Sqrt(Math.Pow(controller.eyes.position.x - controller.keyboardPlayer.transform.position.x, 2)
                                    + Math.Pow(controller.eyes.position.y - controller.keyboardPlayer.transform.position.y, 2));
        
        double MSdistance = Math.Sqrt(Math.Pow(controller.eyes.position.x - controller.mousePlayer.transform.position.x, 2)
                                      + Math.Pow(controller.eyes.position.y - controller.mousePlayer.transform.position.y, 2));
        
        if (KBdistance < controller.sight_range && KBdistance > controller.attack_range) {
            return true;
        }
        
        

        return false;
       
    }
}
