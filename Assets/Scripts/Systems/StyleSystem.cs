using UnityEngine;
using System.Collections.Generic;

public class Ability
{
    public string name;
    public string description;
    public float cooldownTime; // 15s, 30s, or 45s
    public float currentCooldown = 0f;
    public KeyCode activationKey;
}

public class Style
{
    public string styleName;
    public RarityType rarity;
    public Ability ability1; // 15s cooldown
    public Ability ability2; // 30s cooldown
    public Ability ability3; // 45s cooldown
    public bool hasAwakening = false;
    public Awakening awakeningMoveset;
}

public class Awakening
{
    public string awakeningName;
    public List<Ability> awakeningAbilities; // Replaces normal abilities
    public float duration = 30f; // Awakening lasts 30 seconds
    public string cutscenePath; // Path to awakening cutscene
    public bool isActive = false;
}

public class StyleSystem : MonoBehaviour
{
    private Dictionary<string, Style> playerStyles = new Dictionary<string, Style>();
    private Style currentActiveStyle;
    private float awakingDuration = 0f;

    private void Update()
    {
        UpdateCooldowns();
        UpdateAwakening();
    }

    public void RegisterStyle(Style style)
    {
        playerStyles[style.styleName] = style;
    }

    public void SetActiveStyle(string styleName)
    {
        if (playerStyles.ContainsKey(styleName))
        {
            currentActiveStyle = playerStyles[styleName];
        }
    }

    public bool TriggerAbility(int abilityIndex)
    {
        if (currentActiveStyle == null)
            return false;

        Ability ability = abilityIndex switch
        {
            1 => currentActiveStyle.ability1,
            2 => currentActiveStyle.ability2,
            3 => currentActiveStyle.ability3,
            _ => null
        };

        if (ability != null && ability.currentCooldown <= 0)
        {
            ExecuteAbility(ability);
            ability.currentCooldown = ability.cooldownTime;
            return true;
        }

        return false;
    }

    private void ExecuteAbility(Ability ability)
    {
        // Trigger ability animation and effects
        Debug.Log($"Executing ability: {ability.name}");
    }

    public void ActivateAwakening()
    {
        if (currentActiveStyle?.hasAwakening == true)
        {
            // Play awakening cutscene
            PlayAwakeningCutscene(currentActiveStyle.awakeningMoveset.cutscenePath);
            currentActiveStyle.awakeningMoveset.isActive = true;
            awakingDuration = currentActiveStyle.awakeningMoveset.duration;
        }
    }

    private void UpdateAwakening()
    {
        if (currentActiveStyle?.awakeningMoveset?.isActive == true)
        {
            awakingDuration -= Time.deltaTime;
            if (awakingDuration <= 0)
            {
                currentActiveStyle.awakeningMoveset.isActive = false;
            }
        }
    }

    private void PlayAwakeningCutscene(string cutscenePath)
    {
        // Load and play cutscene
        Debug.Log($"Playing awakening cutscene: {cutscenePath}");
    }

    private void UpdateCooldowns()
    {
        if (currentActiveStyle == null)
            return;

        if (currentActiveStyle.ability1.currentCooldown > 0)
            currentActiveStyle.ability1.currentCooldown -= Time.deltaTime;
        if (currentActiveStyle.ability2.currentCooldown > 0)
            currentActiveStyle.ability2.currentCooldown -= Time.deltaTime;
        if (currentActiveStyle.ability3.currentCooldown > 0)
            currentActiveStyle.ability3.currentCooldown -= Time.deltaTime;
    }

    public Style GetCurrentStyle()
    {
        return currentActiveStyle;
    }
}
