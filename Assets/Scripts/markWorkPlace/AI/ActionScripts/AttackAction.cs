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
      
           
           controller.keyboardPlayerHC.DealDamage(
               controller.attackPower,
               HealthController.DamageType.None,
               3,
               localAfterDamageEvent: (arg0, type, i, arg3) => { }
           );
           // execute block of code here
       

    }
    
}
