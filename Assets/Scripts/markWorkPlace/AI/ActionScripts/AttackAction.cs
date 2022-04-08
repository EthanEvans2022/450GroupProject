using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    private float _sinceLastTriggered = 0.0f;
    
    public override void Act (StateController controller)
    {
        Attack (controller);
    }



    private void Attack(StateController controller)
    {
        // do Attack!

        if (_sinceLastTriggered > controller.attack_frequency)
        {
            controller.sprite_renderer.sprite = controller.attackingSprite;
            controller.sprite_renderer.color = Color.red;
            controller.RaiseAttack();
            _sinceLastTriggered = 0;
        }
        else
        {
            _sinceLastTriggered += Time.deltaTime;
        }
    

    }

}
