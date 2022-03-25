using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        controller.sprite_renderer.color = Color.green;
        controller.sprite_renderer.sprite = controller.normalSprite;
        
        Patrol (controller);
    }

    private void Patrol(StateController controller)
    {
        //Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized, Color.green);
        //controller.navMeshAgent.Stop();

        controller.navMeshAgent.destination = controller.wayPointList [controller.nextWayPoint].position;
        controller.navMeshAgent.Resume ();

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
        
    }
}