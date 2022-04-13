using UnityEngine;

public class CombinedController : MovementHandler
{
    private static readonly int MovementX = Animator.StringToHash("MovementX");
    private static readonly int MovementY = Animator.StringToHash("MovementY");
    private Animator _animator;
    public GameObject projectilePrefab;

    public Camera combinedCamera;
    //Configurations
    public float speed = 10;

    //States
    public bool isCombined = true;

    protected Rigidbody2D Rb;

    //Outlets

    //Methods
    protected void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        combinedCamera = GameObject.Find("Combined Camera").GetComponent<Camera>();

    }

    protected void Update()
    {
        if (gameObject.GetComponentInParent<CharacterController>().isPaused) return;
        if (isCombined) CombinedControls();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        
        //Rotate player in direction
        var animationDirection = (GetMouseLocation() - transform.position).normalized * (Rb.velocity.magnitude == 0.0 ? 0.00001f :Rb.velocity.magnitude);
        _animator.SetFloat(MovementX, animationDirection.x);
        _animator.SetFloat(MovementY, animationDirection.y);
        _animator.speed = Rb.velocity.magnitude; //Moving faster should make the animation move faster
    }

    //Controls for when players are combined
    protected void CombinedControls()
    {
        //WASD Movement controls reused
        var keyboardDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            keyboardDirection += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.D))
            keyboardDirection += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.W))
            keyboardDirection += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            keyboardDirection += new Vector2(0, -1);
        Rb.velocity = keyboardDirection.normalized * speed;

        //Rotate player in direction
        var mousePosition = GetMouseLocation();
        var currPos = transform.position;
        var mouseDirection = mousePosition - currPos;

        //Fire Projectile
        if (Input.GetMouseButtonDown(0))
        {
            var projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.up = mouseDirection;
        }
    }


    private Vector3 GetMouseLocation()
    {
        var mousePos = combinedCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}