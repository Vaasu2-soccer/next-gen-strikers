using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private float friction = 0.95f;
    [SerializeField] private float maxBallSpeed = 30f;
    [SerializeField] private float ballMass = 0.43f;
    [SerializeField] private PhysicMaterial ballPhysicMaterial;

    private Vector3 lastFrameVelocity;

    private void Start()
    {
        if (ballRigidbody == null)
            ballRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplyFriction();
        ClampBallSpeed();
        lastFrameVelocity = ballRigidbody.velocity;
    }

    public void KickBall(Vector3 direction, float force)
    {
        ballRigidbody.velocity = direction.normalized * force;
    }

    public void PassBall(Vector3 targetPosition, float power)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        KickBall(direction, power * 15f);
    }

    public void ShootBall(Vector3 direction, float shootPower)
    {
        float shootForce = shootPower * 25f;
        KickBall(direction, shootForce);
    }

    private void ApplyFriction()
    {
        ballRigidbody.velocity *= friction;
    }

    private void ClampBallSpeed()
    {
        if (ballRigidbody.velocity.magnitude > maxBallSpeed)
        {
            ballRigidbody.velocity = ballRigidbody.velocity.normalized * maxBallSpeed;
        }
    }

    public float GetBallSpeed()
    {
        return ballRigidbody.velocity.magnitude;
    }

    public Vector3 GetBallVelocity()
    {
        return ballRigidbody.velocity;
    }
}
