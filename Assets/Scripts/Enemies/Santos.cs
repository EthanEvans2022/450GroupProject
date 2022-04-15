using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Santos : MonoBehaviour
{
    private Animator _animator;

    //Outlets
    private Rigidbody2D _rigidbody;
    private StateController _state;
    private HealthController _health;
    private UnityEngine.AI.NavMeshAgent _nav;

    
    //Config
    private static readonly int MovementX = Animator.StringToHash("MovementX");
    private static readonly int MovementY = Animator.StringToHash("MovementY");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = GetComponent<StateController>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthController>();
        _nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _state.attackEvent += (c) =>
        {

            var target = c.getTarget();
            var health = target.GetComponentInParent<HealthController>();
            health.DealDamage(10);

        };
    }
    

    private void Update()
    {
        var mov = _nav.velocity;
        _animator.SetFloat(MovementX, mov.x);
        _animator.SetFloat(MovementY, mov.y);
        _animator.speed = mov.magnitude; //Moving faster should make the animation move faster
        
        if (_health.currentHealth <= 0)
        {
            DialogueController.instance.textParts = new[]{"And so I killed Robert and unleashed the Red Error.", "Now I can never rest for I know", "that one day he will return","to evaluate the mess that I have made of this quest."};
            DialogueController.instance.currentDialogue = 0;
            DialogueController.instance.NextText();
            
            foreach (var cam in Camera.allCameras)
            {
                cam.backgroundColor = Color.red;
            }
            
            Destroy(gameObject);
        }

    }
}
