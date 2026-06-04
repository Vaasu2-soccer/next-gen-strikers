using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float baseMovementSpeed = 8f;
    [SerializeField] private float sprintSpeed = 12f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private Animator animator;

    private Rigidbody playerRigidbody;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 currentVelocity = Vector3.zero;
    private float currentSpeed = 0f;
    private bool isSprinting = false;
    private float flowSpeedMultiplier = 1f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    private void Move()
    {
        float targetSpeed = isSprinting ? sprintSpeed : baseMovementSpeed;
        targetSpeed *= flowSpeedMultiplier;
        currentSpeed = Mathf.Lerp(currentSpeed, moveDirection.magnitude * targetSpeed, Time.fixedDeltaTime * acceleration);

        if (moveDirection.magnitude > 0)
        {
            // Rotate player toward movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * sensitivity);
        }

        currentVelocity = moveDirection * currentSpeed;
        currentVelocity.y = playerRigidbody.velocity.y; // Preserve gravity
        playerRigidbody.velocity = currentVelocity;
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("Speed", moveDirection.magnitude);
        animator.SetBool("IsSprinting", isSprinting && moveDirection.magnitude > 0);
    }

    public void ApplyFlowSpeedBoost(float multiplier)
    {
        flowSpeedMultiplier = multiplier;
    }

    public void ResetFlowBoosts()
    {
        flowSpeedMultiplier = 1f;
    }

    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
}
