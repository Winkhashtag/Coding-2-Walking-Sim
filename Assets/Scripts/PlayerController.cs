using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
	public float moveSpeed = 12;
    private float gravity = 9.8f;
    public float groundCheckRadius = 0.15f;

    private CharacterController controller;

    private bool isGrounded;
    private Vector3 velocity;
    private Transform feet;

    public LayerMask groundLayer;

    private void Awake()
    {

        controller = GetComponent<CharacterController>();
    
    feet = transform.Find("feet");
    }
    private void Update()
    {
        CheckIsGrounded();
        Move();
        ApplyGravity();
    
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move);
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundCheckRadius, groundLayer);
    }

    private void ApplyGravity()
    {
        velocity += Vector3.down * gravity * Time.deltaTime;
        if (isGrounded)
            velocity = Vector3.zero;

        controller.Move(velocity);
    }

}
