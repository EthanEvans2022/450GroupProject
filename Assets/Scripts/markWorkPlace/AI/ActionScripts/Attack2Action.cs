using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack2")]
public class Attack2Action : Action 
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
