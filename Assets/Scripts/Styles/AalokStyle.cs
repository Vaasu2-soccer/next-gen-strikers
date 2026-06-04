using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 🌌 AALOK - ETERNAL APEX RARITY
/// Genius Playmaker / Tempo Controller / Vision Core
/// "The best play isn't forced. It simply becomes the only option left."
/// </summary>
public class AalokStyle : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ParticleSystem constellationLinesVFX;
    [SerializeField] private ParticleSystem predictiveTrailsVFX;
    [SerializeField] private ParticleSystem orbitalRingVFX;
    [SerializeField] private ParticleSystem fieldGridVFX;

    // Stats
    private float vision = 100f;
    private float passing = 100f;
    private float ballControl = 98f;
    private float dribbling = 94f;
    private float speed = 86f;
    private float shooting = 90f;
    private float iq = 100f;
    private float stamina = 88f;

    // Passive: Pattern Reading
    private bool patternReadingActive = false;
    private float patternReadingDuration = 0.5f;

    // Base Moves
    private Ability celestialThread;
    private Ability orbitStep;
    private Ability quietCommand;

    // Awakening
    private bool isAwakened = false;
    private float awakeningDuration = 0f;
    private Ability harmonicPlaybook;
    private Ability supernovaSplit;
    private Ability eternalApex;

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
        // Move 1: Celestial Thread (18s cooldown)
        celestialThread = new Ability
        {
            name = "Celestial Thread",
            description = "Pinpoint through pass with predictive trajectory",
            cooldownTime = 18f,
            currentCooldown = 0f,
            activationKey = KeyCode.Z
        };

        // Move 2: Orbit Step (20s cooldown)
        orbitStep = new Ability
        {
            name = "Orbit Step",
            description = "Smooth circular dribble for escape and repositioning",
            cooldownTime = 20f,
            currentCooldown = 0f,
            activationKey = KeyCode.V
        };

        // Move 3: Quiet Command (25s cooldown)
        quietCommand = new Ability
        {
            name = "Quiet Command",
            description = "Team buff and field control",
            cooldownTime = 25f,
            currentCooldown = 0f,
            activationKey = KeyCode.B
        };

        // Awakening Moves
        harmonicPlaybook = new Ability
        {
            name = "Harmonic Playbook",
            description = "Auto-generate attacking structure",
            cooldownTime = 30f,
            currentCooldown = 0f,
            activationKey = KeyCode.Z
        };

        supernovaSplit = new Ability
        {
            name = "Supernova Split",
            description = "High-risk curved shot or defense-splitting pass",
            cooldownTime = 38f,
            currentCooldown = 0f,
            activationKey = KeyCode.V
        };

        eternalApex = new Ability
        {
            name = "Eternal Apex",
            description = "Ultimate move - time slows, see 3 future routes",
            cooldownTime = 60f,
            currentCooldown = 0f,
            activationKey = KeyCode.B
        };
    }

    private void HandleInput()
    {
        if (isAwakened)
        {
            HandleAwakeningInput();
        }
        else
        {
            HandleBaseInput();
        }
    }

    private void HandleBaseInput()
    {
        if (Input.GetKeyDown(celestialThread.activationKey) && celestialThread.currentCooldown <= 0)
        {
            ExecuteCelestialThread();
            celestialThread.currentCooldown = celestialThread.cooldownTime;
        }

        if (Input.GetKeyDown(orbitStep.activationKey) && orbitStep.currentCooldown <= 0)
        {
            ExecuteOrbitStep();
            orbitStep.currentCooldown = orbitStep.cooldownTime;
        }

        if (Input.GetKeyDown(quietCommand.activationKey) && quietCommand.currentCooldown <= 0)
        {
            ExecuteQuietCommand();
            quietCommand.currentCooldown = quietCommand.cooldownTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isAwakened)
        {
            ActivateAwakening();
        }
    }

    private void HandleAwakeningInput()
    {
        if (Input.GetKeyDown(harmonicPlaybook.activationKey) && harmonicPlaybook.currentCooldown <= 0)
        {
            ExecuteHarmonicPlaybook();
            harmonicPlaybook.currentCooldown = harmonicPlaybook.cooldownTime;
        }

        if (Input.GetKeyDown(supernovaSplit.activationKey) && supernovaSplit.currentCooldown <= 0)
        {
            ExecuteSupernovaSplit();
            supernovaSplit.currentCooldown = supernovaSplit.cooldownTime;
        }

        if (Input.GetKeyDown(eternalApex.activationKey) && eternalApex.currentCooldown <= 0)
        {
            ExecuteEternalApex();
            eternalApex.currentCooldown = eternalApex.cooldownTime;
        }
    }

    // BASE MOVESET
    private void ExecuteCelestialThread()
    {
        Debug.Log("Executing: Celestial Thread - Pinpoint through pass");
        PlayVFX("Silver-blue star thread connecting passer to receiver");
        PlayVFX("Micro constellation burst on release");
        PlaySFX("Soft cosmic wind tone");
        PlaySFX("Clean crystalline chime");
    }

    private void ExecuteOrbitStep()
    {
        Debug.Log("Executing: Orbit Step - Circular dribble escape");
        PlayVFX("Orbital ring around feet");
        PlayVFX("Blue-white trail arcs");
        PlaySFX("Smooth rotational swoosh");
        PlaySFX("Subtle echoing pulse");
    }

    private void ExecuteQuietCommand()
    {
        Debug.Log("Executing: Quiet Command - Team buff and field control");
        PlayVFX("Field-wide faint grid overlay");
        PlayVFX("Soft glowing nodes above teammates");
        PlaySFX("Low harmonic hum");
        PlaySFX("Distant orchestral swell");
    }

    // AWAKENING MOVESET
    private void ExecuteHarmonicPlaybook()
    {
        Debug.Log("Executing: Harmonic Playbook - Auto-generated attacking structure");
        PlayDialogue("Everything is already connected. I'm just aligning it. Now move.");
        PlayVFX("Constellation network expands across field");
        PlayVFX("Flowing light paths between players");
    }

    private void ExecuteSupernovaSplit()
    {
        Debug.Log("Executing: Supernova Split - Curved shot or mega through pass");
        PlayDialogue("There are no wrong choices. Only better timing. Watch.");
        PlayVFX("Starburst explosion trail");
        PlayVFX("Light bending around ball path");
    }

    private void ExecuteEternalApex()
    {
        Debug.Log("Executing: Eternal Apex - Ultimate move with time slowdown");
        PlayDialogue("This is the outcome that fits the moment. Not forced. Just correct.");
        PlayVFX("Entire field becomes a galaxy map");
        PlayVFX("Floating constellation pathways");
        PlayVFX("Silver supernova burst on execution");
    }

    private void ActivateAwakening()
    {
        if (isAwakened) return;

        Debug.Log("Activating: ETERNAL CONSTELLATION - ORIGIN CORE Awakening");
        isAwakened = true;
        awakeningDuration = 30f;

        PlayAwakeningCutscene();

        harmonicPlaybook.currentCooldown = 0f;
        supernovaSplit.currentCooldown = 0f;
        eternalApex.currentCooldown = 0f;
    }

    private void PlayAwakeningCutscene()
    {
        Debug.Log("Playing Awakening Cutscene: ETERNAL CONSTELLATION - ORIGIN CORE");
        Debug.Log("[CUTSCENE] Stadium lights dim...");
        Debug.Log("[CUTSCENE] Grass fades into starfield...");
        Debug.Log("[CUTSCENE] Players freeze as time hesitates...");
        Debug.Log("[CUTSCENE] Sky fractures into geometric constellations...");
        Debug.Log("[CUTSCENE] Each player becomes a moving point of light...");
        Debug.Log("[CUTSCENE] Aalok closes his eyes...");
        Debug.Log("[CUTSCENE] When he opens them - he already knows every possible outcome...");
        
        PlayAwakeningDialogue();
    }

    private void PlayAwakeningDialogue()
    {
        Debug.Log("[AALOK] I don't need to force anything.");
        Debug.Log("[AALOK] The field already knows what it wants to do.");
        Debug.Log("[AALOK] I'm just listening.");
    }

    private void UpdateAwakening()
    {
        if (isAwakened)
        {
            awakeningDuration -= Time.deltaTime;
            if (awakeningDuration <= 0)
            {
                isAwakened = false;
                Debug.Log("Awakening ended");
            }
        }
    }

    private void UpdateAbilityCooldowns()
    {
        celestialThread.currentCooldown = Mathf.Max(0, celestialThread.currentCooldown - Time.deltaTime);
        orbitStep.currentCooldown = Mathf.Max(0, orbitStep.currentCooldown - Time.deltaTime);
        quietCommand.currentCooldown = Mathf.Max(0, quietCommand.currentCooldown - Time.deltaTime);

        harmonicPlaybook.currentCooldown = Mathf.Max(0, harmonicPlaybook.currentCooldown - Time.deltaTime);
        supernovaSplit.currentCooldown = Mathf.Max(0, supernovaSplit.currentCooldown - Time.deltaTime);
        eternalApex.currentCooldown = Mathf.Max(0, eternalApex.currentCooldown - Time.deltaTime);
    }

    private void PlayVFX(string effectName)
    {
        Debug.Log($"[VFX] {effectName}");
    }

    private void PlaySFX(string soundName)
    {
        Debug.Log($"[SFX] {soundName}");
    }

    private void PlayDialogue(string dialogue)
    {
        Debug.Log($"[AALOK] {dialogue}");
    }

    public string GetStyleName() => "🌌 AALOK - ETERNAL APEX";
    public float GetVision() => vision;
    public float GetPassing() => passing;
    public bool IsAwakened() => isAwakened;
}
