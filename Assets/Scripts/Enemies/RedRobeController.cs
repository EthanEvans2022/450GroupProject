using UnityEngine;
using UnityEngine.AI;

public class RedRobeController : MonoBehaviour
{
    private Animator _animator;

    //Outlets
    private Rigidbody2D _rigidbody;
    private StateController _state;
    private HealthController _health;
    private NavMeshAgent _nav;

    
    //Config
    private static readonly int MovementX = Animator.StringToHash("MovementX");
    private static readonly int MovementY = Animator.StringToHash("MovementY");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = GetComponent<StateController>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthController>();
        _nav = GetComponent<NavMeshAgent>();
        _state.attackEvent += (c) =>
        {

            var target = c.getTarget();
            var health = target.GetComponentInParent<HealthController>();
            health.DealDamage(5);

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
            Destroy(gameObject);
        }

    }
}