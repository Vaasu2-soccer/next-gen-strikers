using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public string playerName;
    public string strikerID;
    public int bucks = 1500; // Daily reward
    public int crystals = 0; // Premium currency

    private Dictionary<string, int> ownedStyles = new Dictionary<string, int>();
    private Dictionary<string, int> ownedFlows = new Dictionary<string, int>();
    private List<RarityType> collectionHistory = new List<RarityType>();

    private void Start()
    {
        // Load player data from database/cache
    }

    public void AddBucks(int amount)
    {
        bucks += amount;
    }

    public void RemoveBucks(int amount)
    {
        if (bucks >= amount)
        {
            bucks -= amount;
        }
    }

    public void AddCrystals(int amount)
    {
        crystals += amount;
    }

    public void AddStyle(string styleName)
    {
        if (ownedStyles.ContainsKey(styleName))
            ownedStyles[styleName]++;
        else
            ownedStyles[styleName] = 1;
    }

    public void AddFlow(string flowName)
    {
        if (ownedFlows.ContainsKey(flowName))
            ownedFlows[flowName]++;
        else
            ownedFlows[flowName] = 1;
    }

    public void RecordRoll(RarityType rarity)
    {
        collectionHistory.Add(rarity);
    }

    public int GetStyleCount(string styleName)
    {
        return ownedStyles.ContainsKey(styleName) ? ownedStyles[styleName] : 0;
    }

    public int GetFlowCount(string flowName)
    {
        return ownedFlows.ContainsKey(flowName) ? ownedFlows[flowName] : 0;
    }
}
