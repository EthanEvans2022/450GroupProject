using UnityEngine;

public class BrownController : MonoBehaviour
{
    private Animator _animator;

    //Outlets
    private Rigidbody2D _rigidbody;
    private StateController _state;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = GetComponent<StateController>();
        _animator = GetComponent<Animator>();
        // _state.listen("attack");
    }

    private void Update()
    {
        var mov = _rigidbody.velocity;
        _animator.SetFloat("MovementX", mov.x);
        _animator.SetFloat("MovementY", mov.y);
        _animator.speed = mov.magnitude; //Moving faster should make the animation move faster

    }
}