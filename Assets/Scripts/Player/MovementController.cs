using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
        
        
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