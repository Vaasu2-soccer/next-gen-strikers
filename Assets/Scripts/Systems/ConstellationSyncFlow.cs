using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 🌠 FLOW: CONSTELLATION SYNC
/// ETERNAL APEX RARITY
/// "When the game becomes noise, I become silence that understands it."
/// </summary>
public class ConstellationSyncFlow : MonoBehaviour
{
    public enum AttributeType
    {
        Vision,
        Passing,
        Dribbling,
        BallControl,
        Speed,
        Acceleration,
        ShootingAccuracy,
        ReactionSpeed,
        Stamina
    }

    [SerializeField] private PlayerController playerController;
    [SerializeField] private AalokStyle aalokStyle;

    private bool flowActive = false;
    private float flowDuration = 0f;
    private float baseFlowDuration = 20f;
    private float passingStackBonus = 0f;
    private float maxPassingStackBonus = 0.1f;
    private float passingStackIncrement = 0.02f;

    private List<AttributeType> selectedAttributes = new List<AttributeType>();
    private Dictionary<AttributeType, float> attributeBuffs = new Dictionary<AttributeType, float>();
    private float baseBuffPercentage = 0.285f; // +25% to +32.5% average is 28.5%

    [SerializeField] private ParticleSystem constellationOverlayVFX;
    [SerializeField] private ParticleSystem lightThreadsVFX;
    [SerializeField] private ParticleSystem galaxyRotationVFX;

    private AudioSource audioSource;
    private float visionRadiusBoost = 1f;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        InitializeAttributeBuffs();
    }

    private void Update()
    {
        if (flowActive)
        {
            UpdateFlow();
        }
    }

    private void InitializeAttributeBuffs()
    {
        foreach (AttributeType attr in System.Enum.GetValues(typeof(AttributeType)))
        {
            attributeBuffs[attr] = 0f;
        }
    }

    public void ActivateFlow()
    {
        if (flowActive) return;

        Debug.Log("=== FLOW ACTIVATED: CONSTELLATION SYNC ===");

        flowActive = true;
        flowDuration = baseFlowDuration;
        passingStackBonus = 0f;

        SelectRandomAttributes(3); // 3 random attributes instead of 4
        ApplyBuffs();
        PlayActivationEffects();
        PlayActivationDialogue();
    }

    private void SelectRandomAttributes(int count)
    {
        selectedAttributes.Clear();
        List<AttributeType> availableAttributes = new List<AttributeType>();

        foreach (AttributeType attr in System.Enum.GetValues(typeof(AttributeType)))
        {
            availableAttributes.Add(attr);
        }

        for (int i = 0; i < count && availableAttributes.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, availableAttributes.Count);
            selectedAttributes.Add(availableAttributes[randomIndex]);
            availableAttributes.RemoveAt(randomIndex);
        }

        Debug.Log($"Selected Attributes: {string.Join(", ", selectedAttributes)}");
    }

    private void ApplyBuffs()
    {
        InitializeAttributeBuffs();

        foreach (var attr in selectedAttributes)
        {
            // Random buff between +25% and +32.5%
            float buffAmount = Random.Range(0.25f, 0.325f);
            attributeBuffs[attr] = buffAmount;
        }

        ApplyBuffsToPlayer();
    }

    private void ApplyBuffsToPlayer()
    {
        foreach (var kvp in attributeBuffs)
        {
            if (kvp.Value > 0)
            {
                float totalBuff = kvp.Value + passingStackBonus;
                Debug.Log($"[FLOW BUFF] {kvp.Key}: +{(totalBuff * 100):F1}%");

                if (kvp.Key == AttributeType.Speed && playerController != null)
                {
                    playerController.ApplyFlowSpeedBoost(1f + totalBuff);
                }
                else if (kvp.Key == AttributeType.Vision)
                {
                    visionRadiusBoost = 1f + totalBuff;
                }
            }
        }
    }

    private void UpdateFlow()
    {
        flowDuration -= Time.deltaTime;

        if (flowDuration <= 0)
        {
            DeactivateFlow();
        }
    }

    /// <summary>
    /// Record successful pass and add stacking bonus
    /// Adaptive Clarity: +2% Passing effectiveness stacking up to +10%
    /// Slight increase in vision radius temporarily
    /// </summary>
    public void RecordSuccessfulPass()
    {
        if (!flowActive) return;

        passingStackBonus = Mathf.Min(passingStackBonus + passingStackIncrement, maxPassingStackBonus);
        Debug.Log($"[FLOW STACK] Successful Pass: Stack Bonus now +{(passingStackBonus * 100):F1}%");

        // Increase vision radius temporarily
        visionRadiusBoost = Mathf.Clamp01(visionRadiusBoost + 0.05f);

        ApplyBuffsToPlayer();
    }

    private void DeactivateFlow()
    {
        Debug.Log("=== FLOW DEACTIVATED ===");
        flowActive = false;
        passingStackBonus = 0f;
        visionRadiusBoost = 1f;

        if (playerController != null)
            playerController.ResetFlowBoosts();

        StopFlowVFX();
        PlayFlowEndDialogue();
    }

    private void PlayActivationEffects()
    {
        Debug.Log("[VFX] Field dims into a star map overlay");
        Debug.Log("[VFX] Players gain glowing trajectory lines");
        Debug.Log("[VFX] Ball gains faint orbiting particles");
        Debug.Log("[VFX] Aalok's vision highlights 3 optimal actions constantly");

        if (constellationOverlayVFX != null) constellationOverlayVFX.Play();
        if (lightThreadsVFX != null) lightThreadsVFX.Play();
        if (galaxyRotationVFX != null) galaxyRotationVFX.Play();
    }

    private void StopFlowVFX()
    {
        if (constellationOverlayVFX != null) constellationOverlayVFX.Stop();
        if (lightThreadsVFX != null) lightThreadsVFX.Stop();
        if (galaxyRotationVFX != null) galaxyRotationVFX.Stop();
    }

    private void PlayActivationDialogue()
    {
        Debug.Log("[AALOK] Let's make this simple.");
        Debug.Log("[AALOK] The answer is already here.");
        Debug.Log("[AALOK] I'll just bring it forward.");
    }

    private void PlayFlowEndDialogue()
    {
        Debug.Log("[AALOK] The structure is there if you look for it.");
    }

    private void PlayFlowSFX()
    {
        Debug.Log("[SFX] Soft cosmic resonance");
        Debug.Log("[SFX] Layered harmonic tones");
        Debug.Log("[SFX] Gentle rising orchestral pattern");
    }

    public bool IsFlowActive() => flowActive;
    public float GetFlowDuration() => flowDuration;
    public float GetPassingStackBonus() => passingStackBonus;
    public float GetVisionRadiusBoost() => visionRadiusBoost;
    public List<AttributeType> GetSelectedAttributes() => selectedAttributes;
}
