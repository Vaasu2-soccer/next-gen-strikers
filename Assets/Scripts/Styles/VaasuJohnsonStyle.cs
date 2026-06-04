using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// VAASU JOHNSON - ABSOLUTE SOVEREIGN
/// Elite Dribbler / Shooter / Playmaker
/// </summary>
public class VaasuJohnsonStyle : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private FlowStateSystem flowSystem;
    [SerializeField] private ParticleSystem platinumEyeGlowVFX;
    [SerializeField] private ParticleSystem goldenTacticalLinesVFX;
    [SerializeField] private ParticleSystem floatingChessPiecesVFX;

    private float speed = 100f;
    private float dribbling = 100f;
    private float shooting = 98f;
    private float defense = 75f;

    private bool sovereignVisionActive = false;
    private bool isAwakened = false;
    private float awakeningDuration = 0f;

    private Ability royalSerpent;
    private Ability monarchsDeception;
    private Ability imperialBreaker;
    private Ability kingsVerdict;

    private void Start()
    {
        InitializeAbilities();
    }

    private void Update()
    {
        UpdateAbilityCooldowns();
        UpdateAwakening();
        HandleInput();
    }

    private void InitializeAbilities()
    {
        royalSerpent = new Ability { name = "Royal Serpent", cooldownTime = 18f, activationKey = KeyCode.Q };
        monarchsDeception = new Ability { name = "Monarch's Deception", cooldownTime = 20f, activationKey = KeyCode.W };
        imperialBreaker = new Ability { name = "Imperial Breaker", cooldownTime = 22f, activationKey = KeyCode.E };
        kingsVerdict = new Ability { name = "King's Verdict", cooldownTime = 25f, activationKey = KeyCode.R };
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAwakened)
        {
            ActivateAwakening();
        }
    }

    private void ActivateAwakening()
    {
        isAwakened = true;
        awakeningDuration = 30f;
        Debug.Log("ABSOLUTE SOVEREIGN Awakening activated!");
    }

    private void UpdateAwakening()
    {
        if (isAwakened)
        {
            awakeningDuration -= Time.deltaTime;
            if (awakeningDuration <= 0)
            {
                isAwakened = false;
            }
        }
    }

    private void UpdateAbilityCooldowns()
    {
        royalSerpent.currentCooldown = Mathf.Max(0, royalSerpent.currentCooldown - Time.deltaTime);
        monarchsDeception.currentCooldown = Mathf.Max(0, monarchsDeception.currentCooldown - Time.deltaTime);
        imperialBreaker.currentCooldown = Mathf.Max(0, imperialBreaker.currentCooldown - Time.deltaTime);
        kingsVerdict.currentCooldown = Mathf.Max(0, kingsVerdict.currentCooldown - Time.deltaTime);
    }

    public void ActivateSovereignVision()
    {
        sovereignVisionActive = true;
        platinumEyeGlowVFX.Play();
        goldenTacticalLinesVFX.Play();
        floatingChessPiecesVFX.Play();
    }

    public string GetStyleName() => "👑 VAASU JOHNSON - ABSOLUTE SOVEREIGN";
    public float GetSpeed() => speed;
    public bool IsAwakened() => isAwakened;
}
