using UnityEngine;

public class CombinedController : MovementHandler
{

    public GameObject projectilePrefab;

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
       
    }

    protected void Update()
    {
        if (isCombined) CombinedControls();
    }

    //Controls for when players are combined
    protected void CombinedControls()
    {
        //WASD Movement controlls reused
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
        //TODO: Change sprite on rotation to match direction of mouse pointing
        transform.up = mouseDirection;

        //Fire Projectile
        if (Input.GetMouseButtonDown(0))
        {
            var projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
        }
    }


    private Vector3 GetMouseLocation()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}