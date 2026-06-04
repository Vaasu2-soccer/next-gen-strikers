using UnityEngine;
using System.Collections.Generic;

public enum SpinType
{
    Standard,  // All rarities
    Lucky,     // Mythic+
    Ultra,     // Godly+
    Infinity   // Infinity+
}

public class SpinResult
{
    public RarityType rarity;
    public string itemName;
    public bool isGlobalAnnouncement;
    public string globalMessage;
}

public class SpinSystem : MonoBehaviour
{
    [SerializeField] private int standardSpinCost = 100;
    [SerializeField] private int luckySpinCost = 750;
    [SerializeField] private int ultraSpinCost = 2000;
    [SerializeField] private int infinitySpinCost = 4000;

    private Dictionary<SpinType, Dictionary<RarityType, float>> dropRates = new Dictionary<SpinType, Dictionary<RarityType, float>>();

    private void Start()
    {
        InitializeDropRates();
    }

    private void InitializeDropRates()
    {
        // Standard Spin - All rarities
        dropRates[SpinType.Standard] = new Dictionary<RarityType, float>
        {
            { RarityType.Common, 40f },
            { RarityType.Uncommon, 30f },
            { RarityType.Rare, 20f },
            { RarityType.Epic, 7f },
            { RarityType.Legendary, 2f },
            { RarityType.Mythic, 0.8f },
            { RarityType.Divine, 0.15f },
            { RarityType.Godly, 0.05f }
        };

        // Lucky Spin - Mythic+
        dropRates[SpinType.Lucky] = new Dictionary<RarityType, float>
        {
            { RarityType.Mythic, 55f },
            { RarityType.Divine, 25f },
            { RarityType.Godly, 10f },
            { RarityType.Transcendent, 5f },
            { RarityType.Secret, 2.5f },
            { RarityType.Infinity, 1.2f },
            { RarityType.Celestial, 0.7f },
            { RarityType.Omniversal, 0.35f },
            { RarityType.BestInHistory, 0.15f },
            { RarityType.EternalApex, 0.08f },
            { RarityType.AbsoluteSovereign, 0.02f }
        };

        // Ultra Spin - Godly+
        dropRates[SpinType.Ultra] = new Dictionary<RarityType, float>
        {
            { RarityType.Godly, 50f },
            { RarityType.Transcendent, 25f },
            { RarityType.Secret, 12f },
            { RarityType.Infinity, 6f },
            { RarityType.Celestial, 3.5f },
            { RarityType.Omniversal, 2f },
            { RarityType.BestInHistory, 1f },
            { RarityType.EternalApex, 0.4f },
            { RarityType.AbsoluteSovereign, 0.1f }
        };

        // Infinity Spin - Infinity+
        dropRates[SpinType.Infinity] = new Dictionary<RarityType, float>
        {
            { RarityType.Infinity, 55f },
            { RarityType.Celestial, 25f },
            { RarityType.Omniversal, 10f },
            { RarityType.BestInHistory, 5f },
            { RarityType.EternalApex, 3.5f },
            { RarityType.AbsoluteSovereign, 1.5f }
        };
    }

    public SpinResult ExecuteSpin(SpinType spinType, PlayerInventory playerInventory)
    {
        // Check currency
        int cost = GetSpinCost(spinType);
        if (playerInventory.bucks < cost)
        {
            return null; // Insufficient funds
        }

        // Deduct cost
        playerInventory.RemoveBucks(cost);

        // Roll rarity
        RarityType resultRarity = RollRarity(spinType);

        SpinResult result = new SpinResult
        {
            rarity = resultRarity,
            itemName = GenerateItemName(resultRarity),
            isGlobalAnnouncement = CheckGlobalAnnouncement(resultRarity),
            globalMessage = GenerateGlobalMessage(resultRarity, playerInventory.playerName)
        };

        return result;
    }

    private RarityType RollRarity(SpinType spinType)
    {
        Dictionary<RarityType, float> rates = dropRates[spinType];
        float roll = Random.Range(0f, 100f);
        float cumulative = 0f;

        foreach (var kvp in rates)
        {
            cumulative += kvp.Value;
            if (roll <= cumulative)
                return kvp.Key;
        }

        // Fallback to highest rarity
        return GetHighestRarity(spinType);
    }

    private RarityType GetHighestRarity(SpinType spinType)
    {
        return spinType switch
        {
            SpinType.Standard => RarityType.Godly,
            SpinType.Lucky => RarityType.AbsoluteSovereign,
            SpinType.Ultra => RarityType.AbsoluteSovereign,
            SpinType.Infinity => RarityType.AbsoluteSovereign,
            _ => RarityType.Common
        };
    }

    private bool CheckGlobalAnnouncement(RarityType rarity)
    {
        return rarity switch
        {
            RarityType.Omniversal => Random.Range(0, 50) == 0,      // 1 in 50
            RarityType.BestInHistory => Random.Range(0, 100) == 0,  // 1 in 100
            RarityType.EternalApex => Random.Range(0, 250) == 0,    // 1 in 250
            RarityType.AbsoluteSovereign => Random.Range(0, 1000) == 0, // 1 in 1000
            _ => false
        };
    }

    private string GenerateGlobalMessage(RarityType rarity, string playerName)
    {
        return rarity switch
        {
            RarityType.Omniversal => $"[GLOBAL] {playerName} rolled O M N I V E R S A L!",
            RarityType.BestInHistory => $"[GLOBAL] {playerName} has become one of the BEST IN HISTORY!",
            RarityType.EternalApex => $"[SERVER SHOCKWAVE] {playerName} reached ETERNAL APEX!",
            RarityType.AbsoluteSovereign => $"[WORLD EVENT] Reality bends as {playerName} obtained ABSOLUTE SOVEREIGN!",
            _ => ""
        };
    }

    private string GenerateItemName(RarityType rarity)
    {
        // Placeholder - would be replaced with actual item names
        return $"{rarity} Item";
    }

    private int GetSpinCost(SpinType spinType)
    {
        return spinType switch
        {
            SpinType.Standard => standardSpinCost,
            SpinType.Lucky => luckySpinCost,
            SpinType.Ultra => ultraSpinCost,
            SpinType.Infinity => infinitySpinCost,
            _ => 0
        };
    }
}
