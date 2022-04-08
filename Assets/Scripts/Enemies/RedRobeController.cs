using UnityEngine;

public class BrownController : MonoBehaviour
{
    private Animator _animator;

    //Outlets
    private Rigidbody2D _rigidbody;
    private StateController _state;
    private HealthController _health;

    
    //Config
    public GameObject projectile;
    private static readonly int MovementX = Animator.StringToHash("MovementX");
    private static readonly int MovementY = Animator.StringToHash("MovementY");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = GetComponent<StateController>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthController>();
        _health.AfterDamageEvent += (damage, a, b, c) =>
        {
            if (_health.currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        };
        _state.attackEvent += (c) =>
        {
            var p = Instantiate(projectile);
            var position = transform.position;
            var a = c.getTarget().transform.position - position;
            p.transform.position = position + a.normalized * 0.7f;
            p.transform.up = a;
        };
    }

    private void Update()
    {
        var mov = _rigidbody.velocity;
        _animator.SetFloat(MovementX, mov.x);
        _animator.SetFloat(MovementY, mov.y);
        _animator.speed = mov.magnitude; //Moving faster should make the animation move faster

    }
}