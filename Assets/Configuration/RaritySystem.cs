using UnityEngine;
using System.Collections.Generic;

public enum RarityType
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic,
    Divine,
    Godly,
    Transcendent,
    Secret,
    Infinity,
    Celestial,
    Omniversal,
    BestInHistory,
    EternalApex,
    AbsoluteSovereign
}

public class RarityConfig
{
    public RarityType type;
    public string name;
    public Color color;
    public string vfxName;
    public string sfxName;
    public int dropOdds; // Out of 10000 for precision
}

public class RaritySystem : MonoBehaviour
{
    private static Dictionary<RarityType, RarityConfig> rarityDatabase = new Dictionary<RarityType, RarityConfig>
    {
        { RarityType.Common, new RarityConfig { type = RarityType.Common, name = "Common", color = new Color(0.6f, 0.6f, 0.6f), vfxName = "DustParticles", sfxName = "SoftClick" } },
        { RarityType.Uncommon, new RarityConfig { type = RarityType.Uncommon, name = "Uncommon", color = new Color(0.3f, 0.8f, 0.3f), vfxName = "GreenSparkles", sfxName = "LightChime" } },
        { RarityType.Rare, new RarityConfig { type = RarityType.Rare, name = "Rare", color = new Color(0.13f, 0.59f, 0.95f), vfxName = "BlueStreaks", sfxName = "CrystalDing" } },
        { RarityType.Epic, new RarityConfig { type = RarityType.Epic, name = "Epic", color = new Color(0.61f, 0.15f, 0.69f), vfxName = "PurpleAura", sfxName = "MagicalWhoosh" } },
        { RarityType.Legendary, new RarityConfig { type = RarityType.Legendary, name = "Legendary", color = new Color(1f, 0.84f, 0), vfxName = "GoldenFlames", sfxName = "TriumphantHorn" } },
        { RarityType.Mythic, new RarityConfig { type = RarityType.Mythic, name = "Mythic", color = new Color(0.86f, 0.08f, 0.24f), vfxName = "RedLightning", sfxName = "DeepImpactBoom" } },
        { RarityType.Divine, new RarityConfig { type = RarityType.Divine, name = "Divine", color = new Color(1f, 1f, 1f), vfxName = "HolyRays", sfxName = "AngelicChoir" } },
        { RarityType.Godly, new RarityConfig { type = RarityType.Godly, name = "Godly", color = new Color(0, 1f, 1f), vfxName = "FloatingRunes", sfxName = "HeavenlyBell" } },
        { RarityType.Transcendent, new RarityConfig { type = RarityType.Transcendent, name = "Transcendent", color = new Color(0.93f, 0.51f, 0.93f), vfxName = "RealityDistortion", sfxName = "EchoingResonance" } },
        { RarityType.Secret, new RarityConfig { type = RarityType.Secret, name = "Secret", color = new Color(0.5f, 0, 0.5f), vfxName = "VoidCracks", sfxName = "DarkBassPulse" } },
        { RarityType.Infinity, new RarityConfig { type = RarityType.Infinity, name = "Infinity", color = new Color(0.29f, 0, 0.51f), vfxName = "InfiniteLoopSymbols", sfxName = "EndlessEcho" } },
        { RarityType.Celestial, new RarityConfig { type = RarityType.Celestial, name = "Celestial", color = new Color(0.27f, 0.51f, 0.71f), vfxName = "Constellations", sfxName = "CosmicChoir" } },
        { RarityType.Omniversal, new RarityConfig { type = RarityType.Omniversal, name = "Omniversal", color = new Color(1f, 0.5f, 0), vfxName = "UniverseExpansion", sfxName = "MultiLayeredCosmicSound" } },
        { RarityType.BestInHistory, new RarityConfig { type = RarityType.BestInHistory, name = "Best in History", color = new Color(0.86f, 0.86f, 0.86f), vfxName = "HistoricSilhouettes", sfxName = "StadiumRoarFanfare" } },
        { RarityType.EternalApex, new RarityConfig { type = RarityType.EternalApex, name = "Eternal Apex", color = new Color(0.5f, 0.25f, 0), vfxName = "TimeStopEffect", sfxName = "DeepCelestialHum" } },
        { RarityType.AbsoluteSovereign, new RarityConfig { type = RarityType.AbsoluteSovereign, name = "Absolute Sovereign", color = new Color(1f, 1f, 1f), vfxName = "RealityShatter", sfxName = "UltimateAscensionSound" } }
    };

    public static RarityConfig GetRarityConfig(RarityType type)
    {
        return rarityDatabase[type];
    }

    public static Color GetRarityColor(RarityType type)
    {
        return GetRarityConfig(type).color;
    }
}
