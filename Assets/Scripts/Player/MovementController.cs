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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}