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
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
 

    private void Attack(StateController controller)
    {
       // do Attack!
       time += Time.deltaTime;
 
       if (time >= interpolationPeriod) {
           time = 0.0f;
           controller.keyboardPlayerHC.DealDamage(-controller.attackPower);

           // execute block of code here
       }

    }
    
}
