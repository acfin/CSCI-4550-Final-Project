using UnityEngine;

public class MovementController : MonoBehaviour
{
    public PlayerStats playerStats;
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speed = playerStats.speed;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
        
        if (moveDirection.Equals(new Vector3(0, 0 , 0)))
        {
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            animator.SetFloat("Speed", .75f);
        }
        
        
        // Update rotation based on movement direction
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        
        // Out of Bounds check
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(3, 1, -3);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        
    }
}