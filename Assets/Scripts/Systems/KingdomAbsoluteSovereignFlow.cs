using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// FLOW: KINGDOM OF THE ABSOLUTE SOVEREIGN
/// All-Round Dominator Flow with stacking bonuses
/// </summary>
public class KingdomAbsoluteSovereignFlow : MonoBehaviour
{
    public enum AttributeType
    {
        Speed, Acceleration, Dribbling, BallControl, ShootingPower,
        ShootingAccuracy, Passing, Vision, ReactionSpeed, Stamina,
        Interceptions, Curve
    }

    [SerializeField] private PlayerController playerController;
    [SerializeField] private VaasuJohnsonStyle vaasuStyle;

    private bool flowActive = false;
    private float flowDuration = 0f;
    private float baseFlowDuration = 15f;
    private float stackBonus = 0f;
    private float maxStackBonus = 0.1f;
    private float stackIncrement = 0.02f;

    private List<AttributeType> selectedAttributes = new List<AttributeType>();
    private Dictionary<AttributeType, float> attributeBuffs = new Dictionary<AttributeType, float>();
    private float baseBuffPercentage = 0.35f;

    [SerializeField] private ParticleSystem platinumWhiteFlamesVFX;
    [SerializeField] private ParticleSystem blackCosmicEnergyVFX;
    [SerializeField] private ParticleSystem floatingGoldFragmentsVFX;
    [SerializeField] private ParticleSystem chessboardFieldVFX;

    private AudioSource audioSource;
    private float sfxTimer = 0f;
    private float sfxInterval = 2f;

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

        Debug.Log("=== FLOW ACTIVATED: KINGDOM OF THE ABSOLUTE SOVEREIGN ===");

        flowActive = true;
        flowDuration = baseFlowDuration;
        stackBonus = 0f;
        sfxTimer = 0f;

        SelectRandomAttributes(4);
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
            attributeBuffs[attr] = baseBuffPercentage;
        }

        ApplyBuffsToPlayer();
    }

    private void ApplyBuffsToPlayer()
    {
        foreach (var kvp in attributeBuffs)
        {
            if (kvp.Value > 0)
            {
                float totalBuff = kvp.Value + stackBonus;
                Debug.Log($"[FLOW BUFF] {kvp.Key}: +{(totalBuff * 100):F1}%");

                if (kvp.Key == AttributeType.Speed && playerController != null)
                {
                    playerController.ApplyFlowSpeedBoost(1f + totalBuff);
                }
                else if (kvp.Key == AttributeType.Vision && vaasuStyle != null)
                {
                    vaasuStyle.ActivateSovereignVision();
                }
            }
        }
    }

    private void UpdateFlow()
    {
        flowDuration -= Time.deltaTime;
        sfxTimer -= Time.deltaTime;

        if (sfxTimer <= 0)
        {
            PlayActiveSFX();
            sfxTimer = sfxInterval;
        }

        if (flowDuration <= 0)
        {
            DeactivateFlow();
        }
    }

    public void RecordSuccessfulAction(ActionType actionType)
    {
        if (!flowActive) return;

        stackBonus = Mathf.Min(stackBonus + stackIncrement, maxStackBonus);
        Debug.Log($"[FLOW STACK] +{actionType}: Stack Bonus now +{(stackBonus * 100):F1}%");

        ApplyBuffsToPlayer();

        if (stackBonus >= maxStackBonus)
        {
            PlayMaximumStacksSFX();
        }
    }

    public enum ActionType { DefeatDefender, CompletePass, LandShot }

    private void DeactivateFlow()
    {
        Debug.Log("=== FLOW DEACTIVATED ===");
        flowActive = false;
        stackBonus = 0f;
        
        if (playerController != null)
            playerController.ResetFlowBoosts();

        StopFlowVFX();
        PlayFlowEndDialogue();
    }

    private void PlayActivationEffects()
    {
        Debug.Log("[VFX] Stadium darkens");
        if (chessboardFieldVFX != null) chessboardFieldVFX.Play();
        if (platinumWhiteFlamesVFX != null) platinumWhiteFlamesVFX.Play();
        if (floatingGoldFragmentsVFX != null) floatingGoldFragmentsVFX.Play();
        if (blackCosmicEnergyVFX != null) blackCosmicEnergyVFX.Play();
        Debug.Log("[VFX] Shattered-space footprints on every step");
    }

    private void StopFlowVFX()
    {
        if (platinumWhiteFlamesVFX != null) platinumWhiteFlamesVFX.Stop();
        if (blackCosmicEnergyVFX != null) blackCosmicEnergyVFX.Stop();
        if (floatingGoldFragmentsVFX != null) floatingGoldFragmentsVFX.Stop();
        if (chessboardFieldVFX != null) chessboardFieldVFX.Stop();
    }

    private void PlayActiveSFX()
    {
        Debug.Log("[SFX] Subtle ticking clock, Echoing footsteps, Low cosmic hum");
    }

    private void PlayMaximumStacksSFX()
    {
        Debug.Log("[SFX] Loud throne-cracking sound, Ascension effect");
    }

    private void PlayActivationDialogue()
    {
        Debug.Log("[VAASU] You've all been playing football.");
        Debug.Log("[VAASU] I've been studying the board.");
        Debug.Log("[VAASU] Now.");
        Debug.Log("[VAASU] Watch the king move.");
    }

    private void PlayFlowEndDialogue()
    {
        string[] endDialogues = new string[]
        {
            "Checkmate.",
            "The game ended three moves ago.",
            "You never understood the position."
        };

        string selectedDialogue = endDialogues[Random.Range(0, endDialogues.Length)];
        Debug.Log($"[VAASU] {selectedDialogue}");
    }

    public bool IsFlowActive() => flowActive;
    public float GetFlowDuration() => flowDuration;
    public float GetStackBonus() => stackBonus;
    public List<AttributeType> GetSelectedAttributes() => selectedAttributes;
}
