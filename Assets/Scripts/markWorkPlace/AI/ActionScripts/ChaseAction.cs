using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action 
{
    public override void Act (StateController controller)
    {
        controller.sprite_renderer.color = Color.yellow;
        controller.sprite_renderer.sprite = controller.normalSprite;
        
        Chase (controller);    
    }

    private void Chase(StateController controller)
    {

        controller.navMeshAgent.destination = controller.keyboardPlayer.transform.position;
        controller.navMeshAgent.Resume ();
    }
}