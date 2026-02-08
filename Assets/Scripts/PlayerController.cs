using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
	public float moveSpeed = 12;
    public float gravity = -9.8f;
    public float groundCheckRadius = 0.15f;

    private CharacterController controller;

    private bool isGrounded;
    private Vector3 velocity;
    private Transform feet;

    public LayerMask groundLayer;

    private bool playingFootsteps = false;
    public float footseptsSpeed = 0.5f;

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


        bool isMoving =
      Input.GetKey(KeyCode.W) ||
      Input.GetKey(KeyCode.A) ||
      Input.GetKey(KeyCode.S) ||
      Input.GetKey(KeyCode.D);

        if (isMoving && isGrounded)
        {
            if (!playingFootsteps)
                StartFootSteps();
        }
        else
        {
            if (playingFootsteps)
                StopFootSteps();
        }

    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move);
       
        //start footsteps
        
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

    void StartFootSteps()
    {
        playingFootsteps = true;
        InvokeRepeating(nameof(PlayFootStep), 0f, footseptsSpeed);
    }
    void StopFootSteps()
    {
        playingFootsteps = false;
        CancelInvoke(nameof(PlayFootStep));
    }

    void PlayFootStep()
    {
        SoundEffectManager.Play("Footstep");
    }

    void OnDrawGizmos()
    {
        if (feet == null) return;

        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(feet.position, groundCheckRadius);
    }
}