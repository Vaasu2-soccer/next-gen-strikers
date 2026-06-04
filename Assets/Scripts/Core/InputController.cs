using UnityEngine;

/// <summary>
/// Input Controller for NEXT GEN STRIKERS
/// Handles all player inputs and maps them to gameplay actions
/// </summary>
public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private VaasuJohnsonStyle vaasuStyle;
    [SerializeField] private AalokStyle aalokStyle;
    [SerializeField] private BallPhysics ballPhysics;
    [SerializeField] private KingdomAbsoluteSovereignFlow vaasuFlow;
    [SerializeField] private ConstellationSyncFlow aalokFlow;

    private bool isHoldingShoot = false;
    private float shootPower = 0f;
    private float maxShootPower = 1f;
    private float shootPowerChargeRate = 1.5f;

    private void Update()
    {
        HandleMovement();
        HandlePassing();
        HandleShooting();
        HandleDribble();
        HandleTackle();
        HandleSprint();
        HandleShiftLock();
        HandleAwakening();
        HandleFlowActivation();
        HandleAbilities();
    }

    private void HandleMovement()
    {
        // Movement is handled by PlayerController via axis input
    }

    private void HandlePassing()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("[INPUT] Pass - M Key");
            // Execute pass logic
        }
    }

    private void HandleShooting()
    {
        // Left-click down - start charging
        if (Input.GetMouseButtonDown(0))
        {
            isHoldingShoot = true;
            shootPower = 0f;
            Debug.Log("[INPUT] Shooting started - Power charging...");
        }

        // Left-click held - increase power
        if (Input.GetMouseButton(0) && isHoldingShoot)
        {
            shootPower = Mathf.Min(shootPower + shootPowerChargeRate * Time.deltaTime, maxShootPower);
            // Display power bar in UI
        }

        // Left-click released - shoot
        if (Input.GetMouseButtonUp(0) && isHoldingShoot)
        {
            isHoldingShoot = false;
            float shootForce = shootPower * 25f; // Max force at full power
            Debug.Log($"[INPUT] Shoot - Power: {shootPower * 100:F1}%");
            ballPhysics.ShootBall(GetShootDirection(), shootForce);
            shootPower = 0f;
        }
    }

    private Vector3 GetShootDirection()
    {
        // Get direction from camera forward or player forward
        return transform.forward;
    }

    private void HandleDribble()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("[INPUT] Dribble - Q Key (can result in ankle breaker if timed right)");
            // Execute dribble logic
        }
    }

    private void HandleTackle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("[INPUT] Tackle - E Key");
            // Execute tackle logic
        }
    }

    private void HandleSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("[INPUT] Sprint - Left Shift");
            playerController.EnableSprint(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerController.EnableSprint(false);
        }
    }

    private void HandleShiftLock()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("[INPUT] Shift Lock - Right Shift");
            playerController.EnableShiftLock(true);
        }

        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            playerController.EnableShiftLock(false);
        }
    }

    private void HandleAwakening()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("[INPUT] Awakening - X Key");
            // Trigger awakening for current style
        }
    }

    private void HandleFlowActivation()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("[INPUT] Flow Activation - F Key");
            // Activate flow state if bar >= 35%
        }
    }

    private void HandleAbilities()
    {
        // Z = Move 1
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("[INPUT] Move 1 - Z Key");
        }

        // V = Move 2
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("[INPUT] Move 2 - V Key");
        }

        // B = Move 3
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("[INPUT] Move 3 - B Key");
        }

        // C = Move 4
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("[INPUT] Move 4 - C Key");
        }
    }

    public float GetShootPower() => shootPower;
    public bool IsChargingShot() => isHoldingShoot;
}
