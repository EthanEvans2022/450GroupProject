using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action 
{
    public override void Act (StateController controller)
    {
        controller.sprite_renderer.sprite = controller.attackingSprite;
        controller.sprite_renderer.color = Color.red;
        
        Attack (controller);
    }

    private void Attack(StateController controller)
    {
       // do Attack!
       

    }
}
